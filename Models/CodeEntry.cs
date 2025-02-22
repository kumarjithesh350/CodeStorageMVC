
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CodeStorageMVC.Models
{
    public class CodeEntry
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("key")]
        public string Key { get; set; }

        [BsonElement("javaCode")]
        public string JavaCode { get; set; }
    }
}
