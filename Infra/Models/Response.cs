using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Newtonsoft.Json;
using Infra.Enum;

namespace Infra.Models
{
    public class Response
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        [BsonElement("fineNumber")]
        public string FineNumber { get; set; }

        [BsonElement("decision")]
        [BsonRepresentation(BsonType.String)]
        public DecisionType Decision { get; set; }

        [BsonElement("decisionDate")]
        public string DecisionDate { get; set; }

        [BsonElement("notes")]
        public string Notes { get; set; }

        [BsonElement("reviewedBy")]
        public string ReviewedBy { get; set; }

        [BsonElement("newAmount")]
        public double? NewAmount { get; set; }

        [BsonElement("currency")]
        public string Currency { get; set; }
    }

}
