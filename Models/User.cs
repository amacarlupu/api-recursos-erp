using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace SupportPageApi.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string Deporte { get; set; } = string.Empty;
    }
}
