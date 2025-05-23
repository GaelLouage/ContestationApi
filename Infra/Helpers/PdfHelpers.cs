using Infra.Dtos;
using Infra.Enum;
using Infra.Models;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Helpers
{
    public class PdfHelpers
    {
        public static void SetHeader(Issuer? issuer, PdfGraphics graphics, PdfFont font)
        {
            //Draw the logo
            PdfBitmap image = new PdfBitmap(issuer.Image);
            graphics.DrawImage(image, 400, -20);
            graphics.DrawString(issuer.Department, font, PdfBrushes.Black, new PointF(0, 0));
            graphics.DrawString(issuer.City, font, PdfBrushes.Black, new PointF(0, 20));
            graphics.DrawString($"{issuer.Address} - {issuer.PostalCode}", font, PdfBrushes.Black, new PointF(0, 40));
            graphics.DrawString($"Date: {DateTime.Now.ToShortDateString()}", font, PdfBrushes.Black, new PointF(0, 60));
        }
        public static void SetSubject(Opposer? getOpposer, ResponseBodyEntity? responseBody, PdfGraphics graphics, PdfFont font)
        {
            // subject
            responseBody.Subject = responseBody.Subject.Replace("[FineNumber]", getOpposer.FineNumber);
            graphics.DrawString(responseBody.Subject, font, PdfBrushes.Black, new PointF(0, 160));
        }
        public static void SetBody(Opposer? getOpposer, Response? getResponse, ResponseBodyEntity? responseBody, PdfGraphics graphics, PdfFont font)
        {
            //body
            responseBody.Body = responseBody.Body.Replace("[Opposer]", getOpposer.FullName);
            responseBody.Body = responseBody.Body.Replace("[dated]", getOpposer.ContestationDate);
            responseBody.Body = responseBody.Body.Replace("[datedSecond]", getOpposer.FineIssueDate);
            responseBody.Body = responseBody.Body.Replace("[FineNumberBody]", getOpposer.FineNumber);
            graphics.DrawString(responseBody.Body, font, PdfBrushes.Black, new PointF(0, 240));

            switch (getResponse.Decision)
            {
                case DecisionType.ACCEPTED:
                    graphics.DrawString(responseBody.Accepted, font, PdfBrushes.Black, new PointF(0, 360));
                    break;
                case DecisionType.REJECTED:
                    graphics.DrawString(responseBody.Rejected, font, PdfBrushes.Black, new PointF(0, 360));
                    break;
            }
        }
        public static void SetFooter(Issuer? issuer, ResponseBodyEntity? responseBody, PdfGraphics graphics, PdfFont font)
        {
            //Draw the logo
            PdfBitmap image = new PdfBitmap(issuer.Signature);
            graphics.DrawImage(image, 400, 650);
            graphics.DrawString($"{responseBody.Footer}", font, PdfBrushes.Black, new PointF(0, 650));
        }

        public static PdfDto GetPdfIntoBase64String(PdfDto pdfDto, PdfDocument document, out MemoryStream mem)
        {
            // Create a MemoryStream to save the PDF.
            mem = new MemoryStream();
            // Save the document to the stream.
            document.Save(mem);
            // Reset the position if you plan to read from it.
            mem.Position = 0;
            byte[] bytes = mem.ToArray();
            pdfDto.PdfByteArray = Convert.ToBase64String(bytes);
            return pdfDto;
        }
    }
}
