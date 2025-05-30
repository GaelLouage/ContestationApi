using Microsoft.AspNetCore.Mvc;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf;
using System.Drawing;
using Infra.Repositories.Interfaces;
using Infra.Models;
using Infra.Dtos;
using Infra.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Infra.Helpers;

namespace ContestationApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
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
        [HttpGet("GetResponses")]
        public async Task<IActionResult> GetResponses()
        {
            return Ok(await _pdfService.GetResponses());
        }
        [HttpGet(Name = "GetPdfBase64String")]
        public async Task<PdfDto> GetPdfBase64String(string fineNumber)
        {
            return await _pdfService.GetPdfBase64String(fineNumber);
        }
        [HttpGet("GetPdfByFineNumber")]
        public async Task<IActionResult> GetPdfByFineNumber(string fineNumber)
        {
            var pdfDto = await _pdfService.GetPdfByFineNumber(fineNumber);
            if(pdfDto is null)
            {
                return NotFound($"Pdf with {fineNumber} not found!");
            }
            return Ok(pdfDto);
        }

        [HttpGet("GetResponseByFineNumber")]
        public async Task<IActionResult> GetResponseByFineNumber(string fineNumber)
        {
            var response = await _pdfService.GetResponseByFineNumber(fineNumber);
            if (response is null) 
                return NotFound();

            return Ok(response);
        }

        [HttpGet("GetOppossers")]
        public async Task<IActionResult> GetOpposers()
        {
            return Ok(await _pdfService.GetOpposers());
        }

        [HttpPost("InsertResponseType")]
        public async Task<IActionResult> InsertResponseType(ResponseDto responseDto)
        {
            var response = await _pdfService.InsertResponseType(responseDto);
            if (response is false)
            {
                return BadRequest();
            }
            return Ok("Response inserted");
        }
        [HttpPatch("UpdateResponseType")]
        public async Task<IActionResult> UpdateResponseType(ResponseDto responseDto)
        {
            var response =  await _pdfService.UpdateResponseType(responseDto); 
            if (response is false)
            {
                return BadRequest();
            }
            return Ok("Response inserted");
        }
    }
}
