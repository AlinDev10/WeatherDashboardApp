using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WeatherDashboardAPI.Domain.Entities
{
    public class UserEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string? UserName { get; set; }
    }
}
