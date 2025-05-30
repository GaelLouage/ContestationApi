using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Models
{
    public class MongoServicePoptions
    {
        public string MongoDatabase { get; set; }
        public string CollectionName { get; set; }
        public string Issuer { get; set; }
        public string Opposer { get; set; }
        public string Response  { get; set; }
        public string ResponseBody { get; set; }
        public string Pdf {  get; set; }
        public string User {  get; set; }
    }
}
