using Microsoft.AspNetCore.Mvc;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf;
using System.Drawing;
using Infra.Repositories.Interfaces;
using Infra.Models;
using Infra.Dtos;
using Infra.Services.Interfaces;

namespace ContestationApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PdfController : ControllerBase
    {
        private readonly IPdfService _pdfService;
        private readonly ILogger<PdfController> _logger;

        public PdfController(ILogger<PdfController> logger,
            IPdfService pdfService)
        {
            _logger = logger;
            _pdfService = pdfService;
        }

        [HttpGet(Name = "GetPdfBase64String")]
        public async Task<PdfDto> GetPdfBase64String(string fineNumber)
        {
            return await _pdfService.GetPdfBase64String(fineNumber);
        }
    }
}
