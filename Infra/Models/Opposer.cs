using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Models
{
    public class Opposer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        [BsonElement("fullName")]
        public string FullName { get; set; }

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

        [BsonElement("contestationDate")]
        public string ContestationDate { get; set; }

        [BsonElement("fineNumber")]
        public string FineNumber { get; set; }

        [BsonElement("fineIssueDate")]
        public string FineIssueDate { get; set; }

        [BsonElement("reasonForFine")]
        public string ReasonForFine { get; set; }

        [BsonElement("reasonForContestation")]
        public string ReasonForContestation { get; set; }

        [BsonElement("attachedDocuments")]
        public List<string> AttachedDocuments { get; set; }
    }
}
