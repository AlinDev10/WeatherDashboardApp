using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using WeatherDashboardAPI.Domain.Entities;
using WeatherDashboardAPI.Domain.Interfaces;
using WeatherDashboardAPI.Infraestructure.Data;

namespace WeatherDashboardAPI.Infraestructure.Repositories
{
    public class WeatherHistoryRepository(AppDbContext dbContext) : IWeatherHistoryRepository
    {
        public async Task<IEnumerable<WeatherHistoryEntity>> GetWeatherHistoriesAsync()
        {
            return await dbContext.WeatherHistory.ToListAsync();
        }

        public async Task<WeatherHistoryEntity?> GetWeatherHistoryByIdAsync(string id)
        {
            return await dbContext.WeatherHistory.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<WeatherHistoryEntity> AddWeatherHistoryAsync(WeatherHistoryEntity weatherHistoryEntity)
        {
            weatherHistoryEntity.Id = ObjectId.GenerateNewId().ToString();
            weatherHistoryEntity.SearchedAt = DateTime.UtcNow;
            weatherHistoryEntity.WeatherData = weatherHistoryEntity.WeatherData; //Check Conversion to JSON object or string
            dbContext.WeatherHistory.Add(weatherHistoryEntity);

            await dbContext.SaveChangesAsync();
            return weatherHistoryEntity;
        }

        public async Task<WeatherHistoryEntity> UpdateWeatherHistoryAsync(WeatherHistoryEntity weatherHistoryEntity)
        {
            var weatherHistoryFromDd = await dbContext.WeatherHistory.FirstOrDefaultAsync(u => u.Id == weatherHistoryEntity.Id);

            if (weatherHistoryFromDd != null)
            {
                weatherHistoryFromDd.UserId = weatherHistoryEntity.UserId;
                weatherHistoryFromDd.CityName = weatherHistoryEntity.CityName;
                weatherHistoryFromDd.CountryCode = weatherHistoryEntity.CountryCode;
                weatherHistoryFromDd.WeatherData = weatherHistoryEntity.WeatherData; //Check Conversion to JSON object or string

                await dbContext.SaveChangesAsync();
                return weatherHistoryFromDd;
            }

            return new WeatherHistoryEntity();
        }

        public async Task<bool> DeleteWeatherHistoryByIdAsync(string id)
        {
            var weatherHistoryFromDd = await dbContext.WeatherHistory.FirstOrDefaultAsync(u => u.Id == id);

            if (weatherHistoryFromDd != null)
            {
                dbContext.WeatherHistory.Remove(weatherHistoryFromDd);
                return await dbContext.SaveChangesAsync() > 0;
            }

            return false;
        }
    }
}
