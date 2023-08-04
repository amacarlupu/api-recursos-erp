using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace SupportPageApi.Models
{
    public class ProductLines
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("img-card")]
        public string ImgLine { get; set; } = null!;

        [BsonElement("title")]
        public string TitleLine { get; set; } = null!;

        [BsonElement("description")]
        public string? Description1 { get; set; }

        [BsonElement("description2")]
        public string? Description2 { get; set; }

        [BsonElement("responsive")]
        public string? IsResponsive { get; set; }
    }
}
