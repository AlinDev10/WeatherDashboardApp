using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WeatherDashboardAPI.Domain.Entities
{
    public class WeatherHistoryEntity
    {
        [BsonId]
        public string? Id { get; set; }

        public UserEntity Users { get; set; } = new UserEntity();

        public string? CityName { get; set; }

        public string? CountryCode { get; set; }

        public DateTime? SearchedAt { get; set; }

        public string? WeatherData { get; set; }
    }
}
