using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace JwtWebAPI.Models
{

    public class CleaningServices
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string? ServiceId { get; set; }

        [BsonElement("Name")]
        public string ServiceName { get; set; } = null!;

        public decimal Price { get; set; }

        public string Category { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Image { get; set; } = null!;
    }
}
