using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WeatherDashboardAPI.Domain.Entities
{
    public class FavoriteCitiesEntity
    {
        [BsonId]
        public string? Id { get; set; }

        public UserEntity Users { get; set; } = new UserEntity();

        public string? CityName { get; set; }

        public string? CountryCode { get; set; }

        public DateTime? AddedAt { get; set; }
    }
}
