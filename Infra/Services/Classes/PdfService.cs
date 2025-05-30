using Infra.Dtos;
using Infra.Enum;
using Infra.Helpers;
using Infra.Mappers;
using Infra.Models;
using Infra.Repositories.Interfaces;
using Infra.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Driver;
using MongoDB.Driver.Core.Servers;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Services.Classes
{
    public class PdfService : PdfBaseService, IPdfService
    {
        public PdfService(
            IConfiguration? config,
            IMongoRepository<Issuer> issuerRepository,
            IMongoRepository<Opposer> opposerRepository,
            IMongoRepository<ResponseBodyEntity> responseBodyRepository,
             IMongoRepository<Pdf> pdfRepository,
            IMongoRepository<Response> responseRepository) :
            base(config, issuerRepository, opposerRepository, responseBodyRepository, pdfRepository, responseRepository)
        {
        }
        public async Task<PdfDto> GetPdfBase64String(string fineNumber)
        {
            var pdfDto = new PdfDto();
            try
            {
                var validation = await ValidationHelpers.ValidateAsync(
                    _issuerRepository,
                    _opposerRepository,
                    _responseRepository,
                    _responseBodyRepository,
                    fineNumber, pdfDto);

                if (validation.IsValid is false)
                {
                    // Handle errors, return or log
                    pdfDto.Errors.Add(validation.Error);
                    return pdfDto;
                }
                var issuer = validation.Result.Issuer;
                var opposer = validation.Result.Opposer;
                var response = validation.Result.Response;
                var responseBody = validation.Result.ResponseBody;

                PdfDocument document = new PdfDocument();
                // Add a page to the document.
                PdfPage page = document.Pages.Add();
                // Create PDF graphics for the page.
                PdfGraphics graphics = page.Graphics;

                // Set the standard font.
                PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 12);
                // filedesign
                PdfHelpers.SetHeader(issuer, graphics, font);
                PdfHelpers.SetSubject(opposer, responseBody, graphics, font);
                PdfHelpers.SetBody(opposer, response, responseBody, graphics, font);
                PdfHelpers.SetFooter(issuer, responseBody, graphics, font);

                MemoryStream mem;
                var pdfFile = PdfHelpers.GetPdfIntoBase64String(pdfDto, document, out mem);
                pdfDto.FineNumber = fineNumber;
                await SavePdfAsync(pdfFile);

                return pdfFile;
            }
            catch (Exception ex)
            {
                pdfDto.Errors.Add(ex.Message);
                return pdfDto;
            }
        }
        public async Task<PdfDto?> GetPdfByFineNumber(string fineNumber)
        {
            var pdfdto = new PdfDto();
            var pdf = (await _pdfRepository
                .GetAllAsync())
                .ToList()
                .FirstOrDefault(x => x.FineNumber.Equals(fineNumber, StringComparison.InvariantCultureIgnoreCase));
            if (pdf is null)
            {
                return null;
            }
            pdfdto.FineNumber = fineNumber;
            pdfdto.PdfByteArray = pdf.PdfBase64String;
            return pdfdto;
        }
        public async Task<List<OpposerDto>> GetOpposers()
        {
            var opposersDto = new List<OpposerDto>();
            var opposers = (await _opposerRepository.GetAllAsync()).ToList();
            foreach (var opposer in opposers)
            {
                opposersDto.Add(opposer.MapToOpposerDto());
            }
            return opposersDto;
        }
        public async Task<List<Response>> GetResponses()  =>
            (await _responseRepository.GetAllAsync()).ToList();
        
        public async Task<ResponseDto?> GetResponseByFineNumber(string fineNumber)
        {
            var responseDto = new ResponseDto();

            var response = (await _responseRepository
                .GetAllAsync())
                .FirstOrDefault(x => x.FineNumber
                .Equals(fineNumber, StringComparison.InvariantCultureIgnoreCase));

            if (response is null || string.IsNullOrEmpty(response.FineNumber))
            {
                return null;
            }
            responseDto = response.MapToResponseDto();
            return responseDto;
        }
        public async Task<bool> InsertResponseType(ResponseDto response)
        {
            var opposer = (await _opposerRepository
                .GetAllAsync())
                .FirstOrDefault(x => x.FineNumber
                .Equals(response.FineNumber, StringComparison.InvariantCultureIgnoreCase));

            if (opposer is null || string.IsNullOrEmpty(opposer.FineNumber))
            {
                return false;
            }
            var hasDecision = (await _responseRepository.GetAllAsync()).FirstOrDefault(x => x.FineNumber.Equals(response.FineNumber, StringComparison.InvariantCultureIgnoreCase));
            if (hasDecision is not null)
            {
                return false;
            }
            var insertResponse = await _responseRepository.InsertAsync(new Response()
            {
                FineNumber = response.FineNumber,
                Decision = response.Decision,
                DecisionDate = DateTime.Now.ToShortDateString(),
                ReviewedBy = response.ReviewedBy,
                Notes = response.Notes,
                Currency = response.Currency,
            });
            if (insertResponse is false)
            {
                return false;
            }
            return true;
        }
        public async Task<bool> UpdateResponseType(ResponseDto response)
        {
            var opposer = (await _opposerRepository
                .GetAllAsync())
                .FirstOrDefault(x => x.FineNumber
                .Equals(response.FineNumber, StringComparison.InvariantCultureIgnoreCase));
           
            var getPdf = (await _pdfRepository
                .GetAllAsync())
                .FirstOrDefault(x => x.FineNumber
                .Equals(response.FineNumber, StringComparison.InvariantCultureIgnoreCase));

            var getResponse = (await _responseRepository.GetAllAsync())
                .FirstOrDefault(x => x.FineNumber
                .Equals(response.FineNumber, StringComparison.InvariantCultureIgnoreCase));

            
            if (opposer is null || string.IsNullOrEmpty(opposer.FineNumber))
            {
                return false;
            }

            var hasDecision = (await _responseRepository.GetAllAsync()).FirstOrDefault(x => x.FineNumber.Equals(response.FineNumber, StringComparison.InvariantCultureIgnoreCase));

            if (hasDecision is null)
            {
                return false;
            }
            if (getResponse is null)
            {
                return false;
            }
            if(response.Decision == DecisionType.NONE)
            {
                await _responseRepository.DeleteAsync(getResponse.Id);
            }
            await _pdfRepository.DeleteAsync(getPdf.Id);

            getResponse.Decision = response.Decision;
            getResponse.DecisionDate = DateTime.Now.ToShortDateString();
            getResponse.ReviewedBy = response.ReviewedBy;
            getResponse.Notes = response.Notes;
            getResponse.Currency = response.Currency;
            await _responseRepository.UpdateAsync(getResponse.Id, getResponse);

            return true;
        }
        protected override async Task SavePdfAsync(PdfDto pdf)
        {
            await _pdfRepository.InsertAsync(new Pdf() { PdfBase64String = pdf.PdfByteArray, FineNumber = pdf.FineNumber });
        }
    }
}
