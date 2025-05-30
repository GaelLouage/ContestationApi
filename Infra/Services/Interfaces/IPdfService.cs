using Infra.Dtos;
using Infra.Enum;
using Infra.Models;

namespace Infra.Services.Interfaces
{
    public interface IPdfService
    {
        Task<PdfDto> GetPdfBase64String(string fineNumber);
        Task<List<OpposerDto>> GetOpposers();
        Task<PdfDto?> GetPdfByFineNumber(string fineNumber);
        Task<List<Response>> GetResponses();
        Task<ResponseDto?> GetResponseByFineNumber(string fineNumber);
        Task<bool> InsertResponseType(ResponseDto response);
        Task<bool> UpdateResponseType(ResponseDto response);
    }
}