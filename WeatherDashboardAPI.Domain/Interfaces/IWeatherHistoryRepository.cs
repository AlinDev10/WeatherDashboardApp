using WeatherDashboardAPI.Domain.Entities;

namespace WeatherDashboardAPI.Domain.Interfaces
{
    public interface IWeatherHistoryRepository
    {
        Task<IEnumerable<WeatherHistoryEntity>> GetWeatherHistoriesAsync();
        Task<WeatherHistoryEntity?> GetWeatherHistoryByIdAsync(string id);
        Task<WeatherHistoryEntity> AddWeatherHistoryAsync(WeatherHistoryEntity weatherHistoryEntity);
        Task<WeatherHistoryEntity> UpdateWeatherHistoryAsync(WeatherHistoryEntity weatherHistoryEntity);
        Task<bool> DeleteWeatherHistoryByIdAsync(string id);
    }
}
