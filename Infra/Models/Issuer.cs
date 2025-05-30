using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Newtonsoft.Json;
using System.Drawing;
using Infra.Dtos;

namespace Infra.Models
{
    public class Issuer
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("department")]
        public string Department { get; set; }

        [BsonElement("address")]
        public string Address { get; set; }

        [BsonElement("city")]
        public string City { get; set; }

        [BsonElement("postalCode")]
        public string PostalCode { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("phone")]
        public string Phone { get; set; }

        [BsonElement("officialName")]
        public string OfficialName { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }
        [BsonElement("image")]
        public string Image { get; set; }
        [BsonElement("signature")]
        public string Signature { get;  set; }
    }
}
