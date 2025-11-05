using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WeatherDashboardAPI.Domain.Entities
{
    public class FavoriteCitiesEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonRequired]
        [BsonElement("user_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? UserId { get; set; }

        [BsonElement("city_name")]
        public string? CityName { get; set; }

        [BsonElement("country_code")]
        public string? CountryCode { get; set; }

        [BsonElement("added_at")]
        public DateTime? AddedAt { get; set; }
    }
}
