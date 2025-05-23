using Infra.Dtos;
using Infra.Enum;
using Infra.Helpers;
using Infra.Models;
using Infra.Repositories.Interfaces;
using Infra.Services.Interfaces;
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
            IMongoRepository<Issuer> issuerRepository, 
            IMongoRepository<Opposer> opposerRepository,
            IMongoRepository<ResponseBodyEntity> responseBodyRepository, 
            IMongoRepository<Response> responseRepository) :
            base(issuerRepository, opposerRepository, responseBodyRepository, responseRepository)
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
                PdfHelpers.SetFooter(issuer,responseBody, graphics, font);

                MemoryStream mem;
                return PdfHelpers.GetPdfIntoBase64String(pdfDto, document, out mem);
            }
            catch (Exception ex)
            {
                pdfDto.Errors.Add(ex.Message);
                return pdfDto;
            }
        }
    }
}
