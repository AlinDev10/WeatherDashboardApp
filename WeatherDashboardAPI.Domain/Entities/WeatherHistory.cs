using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WeatherDashboardAPI.Domain.Entities
{
    public class WeatherHistory
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public Users Users { get; set; } = new Users();

        public string? CityName { get; set; }

        public string? CountryCode { get; set; }

        public DateTime? SearchedAt { get; set; }

        public string? WeatherData { get; set; }
    }
}
