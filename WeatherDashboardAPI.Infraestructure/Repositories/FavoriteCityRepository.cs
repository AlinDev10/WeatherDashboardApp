using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using WeatherDashboardAPI.Domain.Entities;
using WeatherDashboardAPI.Domain.Interfaces;
using WeatherDashboardAPI.Infraestructure.Data;

namespace WeatherDashboardAPI.Infraestructure.Repositories
{
    public class FavoriteCityRepository(AppDbContext dbContext) : IFavoriteCityRepository
    {
        public async Task<IEnumerable<FavoriteCitiesEntity>> GetFavoriteCitiesAsync()
        {
            return await dbContext.FavoriteCities.ToListAsync();
        }

        public async Task<FavoriteCitiesEntity?> GetFavoriteCityByIdAsync(string id)
        {
            return await dbContext.FavoriteCities.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<FavoriteCitiesEntity> AddFavoriteCityAsync(FavoriteCitiesEntity favoriteCitiesEntity)
        {
            favoriteCitiesEntity.Id = ObjectId.GenerateNewId().ToString();
            favoriteCitiesEntity.AddedAt = DateTime.UtcNow;
            dbContext.FavoriteCities.Add(favoriteCitiesEntity);

            await dbContext.SaveChangesAsync();
            return favoriteCitiesEntity;
        }

        public async Task<FavoriteCitiesEntity> UpdateFavoriteCityAsync(FavoriteCitiesEntity favoriteCitiesEntity)
        {
            var favoriteCityFromDd = await dbContext.FavoriteCities.FirstOrDefaultAsync(u => u.Id == favoriteCitiesEntity.Id);

            if (favoriteCityFromDd != null)
            {
                favoriteCityFromDd.UserId = favoriteCitiesEntity.UserId;
                favoriteCityFromDd.CityName = favoriteCitiesEntity.CityName;
                favoriteCityFromDd.CountryCode = favoriteCitiesEntity.CountryCode;

                await dbContext.SaveChangesAsync();
                return favoriteCityFromDd;
            }

            return new FavoriteCitiesEntity();
        }

        public async Task<bool> DeleteFavoriteCityByIdAsync(string id)
        {
            var favoriteCityFromDd = await dbContext.FavoriteCities.FirstOrDefaultAsync(u => u.Id == id);

            if (favoriteCityFromDd != null)
            {
                dbContext.FavoriteCities.Remove(favoriteCityFromDd);
                return await dbContext.SaveChangesAsync() > 0;
            }

            return false;
        }
    }
}
