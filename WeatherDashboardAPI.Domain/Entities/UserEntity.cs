using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace WeatherDashboardAPI.Domain.Entities
{
    public class UserEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        
        [Required]
        [MaxLength(50, ErrorMessage = "User name must be max 50 characters.")]
        [BsonElement("username")]
        public string? UserName { get; set; }
    }
}
