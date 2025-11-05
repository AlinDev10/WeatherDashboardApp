using WeatherDashboardAPI.Domain.Entities;

namespace WeatherDashboardAPI.Domain.Interfaces
{
    public interface IFavoriteCityRepository
    {
        Task<IEnumerable<FavoriteCitiesEntity>> GetFavoriteCitiesAsync();
        Task<FavoriteCitiesEntity?> GetFavoriteCityByIdAsync(string id);
        Task<FavoriteCitiesEntity> AddFavoriteCityAsync(FavoriteCitiesEntity favoriteCitiesEntity);
        Task<FavoriteCitiesEntity> UpdateFavoriteCityAsync(FavoriteCitiesEntity favoriteCitiesEntity);
        Task<bool> DeleteFavoriteCityByIdAsync(string id);
    }
}
