using Infra.Dtos;
using Infra.Models;
using Infra.Repositories.Interfaces;

namespace Infra.Helpers
{
    public class ValidationHelpers
    {
        public static async Task<(string Error, bool IsValid, ValidationResult Result)> ValidateAsync(
            IMongoRepository<Issuer> _issuerRepository,
            IMongoRepository<Opposer> _opposerRepository,
            IMongoRepository<Response> _responseRepository,
            IMongoRepository<ResponseBodyEntity> _responseBodyRepository,
            string fineNumber,
            PdfDto pdfDto)
        {
            var result = new ValidationResult { PdfDto = pdfDto };

            result.Issuer = (await _issuerRepository.GetAllAsync()).FirstOrDefault();
            if (result.Issuer is null)
            {
                return ("Issuer not found.", false, result);
            }

            var getOpposerList = await _opposerRepository.GetAllAsync();
            if (getOpposerList is null)
            {
                return ("No opposers in database.", false, result);
            }

            result.Opposer = getOpposerList.FirstOrDefault(x => x.FineNumber == fineNumber);
            if (result.Opposer is null || string.IsNullOrEmpty(result.Opposer.FineNumber))
            {
                return ("Fine number not found!", false, result);
            }

            var getResponseList = await _responseRepository.GetAllAsync();
            if (getResponseList is null)
            {
                return ("No responses found.", false, result);
            }

            result.Response = getResponseList.FirstOrDefault(x => x.FineNumber == fineNumber);
            if (result.Response is null)
            {
                return ("Response not found!", false, result);
            }

            result.ResponseBody = (await _responseBodyRepository.GetAllAsync()).FirstOrDefault();
            if (result.ResponseBody is null)
            {
                return ("Response body not found.", false, result);
            }

            return ("succes", true, result);
        }
    }
}
