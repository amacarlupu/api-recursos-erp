using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SupportPageApi.Models
{
    public class ResourcesPage
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("id_section")]
        public string id_section { get; set; } = null!;

        public string title_section  { get; set; } = null!;

        public object [] item { get; set; } = null!;
    }
}
