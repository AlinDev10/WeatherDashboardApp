namespace WeatherDashboardAPI.Domain.Models
{
    public class MongoDBSettings
    {
        public const string SectionName = "MongoDB";
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string CollectionName { get; set; } = null!;
    }
}
