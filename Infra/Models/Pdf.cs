using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Infra.Models
{
    public class Pdf
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        [BsonElement("fineNumber")]
        public string FineNumber { get; set; }
        [BsonElement("pdfBase64String")]
        public string PdfBase64String { get; set; }
    }
}
