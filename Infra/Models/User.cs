using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Infra.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        [BsonElement("userName")]
        public string UserName { get; set; }
        [BsonElement("passwordHash")]
        public string Password { get; set; }
    }
}
