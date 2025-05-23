using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Infra.Models
{
    public class ResponseBodyEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        [BsonElement("subject")]
        public string Subject { get; set; }
        [BsonElement("body")]
        public string Body { get; set; }

        [BsonElement("accepted")]
        public string Accepted { get; set; }

        [BsonElement("rejected")]
        public string Rejected { get; set; }
        [BsonElement("footer")]
        public string Footer { get; set; }
    }
}
