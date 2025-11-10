using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace WeatherDashboardAPI.Domain.Entities
{
    public class WeatherHistoryEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonRequired]
        [BsonElement("user_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? UserId { get; set; }

        [MaxLength(100, ErrorMessage = "City name must be max 100 characters.")]
        [BsonElement("city_name")]
        public string? CityName { get; set; }

        [MaxLength(2, ErrorMessage = "Country Code must be max 2 characters.")]
        [BsonElement("country_code")]
        public string? CountryCode { get; set; }

        [BsonElement("searched_at")]
        public DateTime? SearchedAt { get; set; }

        [BsonElement("weather_data")]
        public string? WeatherData { get; set; }
    }
}
