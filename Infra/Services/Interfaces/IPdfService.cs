using Infra.Dtos;
using Infra.Enum;

namespace Infra.Services.Interfaces
{
    public interface IPdfService
    {
        Task<PdfDto> GetPdfBase64String(string fineNumber);
    }
}