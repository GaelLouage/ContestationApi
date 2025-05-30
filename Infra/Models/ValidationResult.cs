using Infra.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Models
{
    public class ValidationResult
    {
        public PdfDto PdfDto { get; set; } = new();
        public Issuer? Issuer { get; set; }
        public Opposer? Opposer { get; set; }
        public Response? Response { get; set; }
        public ResponseBodyEntity? ResponseBody { get; set; }
    }
}
