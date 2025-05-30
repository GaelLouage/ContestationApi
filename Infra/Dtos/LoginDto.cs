using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Infra.Dtos
{
    public class LoginDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
