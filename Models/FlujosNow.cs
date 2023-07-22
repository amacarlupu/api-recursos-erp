using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace SupportPageApi.Models
{
    public class FlujosNow
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("id_section")]
        public string Id_section { get; set; } = null!;

        [BsonElement("description")]
        public string Description { get; set; } = null!;

        public object[] position { get; set; } = null!;
    }
}
