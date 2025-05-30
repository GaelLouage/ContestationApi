using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Dtos
{
    public class PdfDto
    {
  
        public List<string> Errors { get; set; } = new List<string>();
        public string FineNumber { get; set; }
        public string PdfByteArray { get; set; }
    }
}
