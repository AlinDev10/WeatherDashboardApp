using WeatherDashboardAPI.Domain.Entities;

namespace WeatherDashboardAPI.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserEntity>> GetUsersAsync();
        Task<UserEntity?> GetUserByIdAsync(string id);
        Task<UserEntity> AddUserAsync(UserEntity userEntity);
        Task<UserEntity> UpdateUserAsync(UserEntity userEntity);
        Task<bool> DeleteUserByIdAsync(string id);
    }
}
