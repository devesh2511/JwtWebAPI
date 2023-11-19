using MongoDB.Bson.Serialization.Attributes;
using System.Numerics;

namespace JwtWebAPI
{
    public class User
    {
        public string Username { get; set; } = String.Empty;
        public string Name { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public long Phone { get; set; }
        //public Booking[] Bookings { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; internal set; }
    }
}
