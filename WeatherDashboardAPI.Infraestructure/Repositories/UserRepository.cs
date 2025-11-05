using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using WeatherDashboardAPI.Domain.Entities;
using WeatherDashboardAPI.Domain.Interfaces;
using WeatherDashboardAPI.Infraestructure.Data;

namespace WeatherDashboardAPI.Infraestructure.Repositories
{

    public class UserRepository(AppDbContext dbContext) : IUserRepository
    {
        public async Task<IEnumerable<UserEntity>> GetUsersAsync() {

            return await dbContext.Users.ToListAsync();
        }

        public async Task<UserEntity?> GetUserByIdAsync(string id) 
        {
            return await dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<UserEntity> AddUserAsync(UserEntity userEntity)
        {
            userEntity.Id = ObjectId.GenerateNewId().ToString();
            dbContext.Users.Add(userEntity);

            await dbContext.SaveChangesAsync();
            return userEntity;
        }

        public async Task<UserEntity> UpdateUserAsync(UserEntity userEntity)
        {
            var userFromDd = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == userEntity.Id);

            if (userFromDd != null)
            {
                userFromDd.UserName = userEntity.UserName;

                await dbContext.SaveChangesAsync();
                return userFromDd;
            }

            return new UserEntity();
        }

        public async Task<bool> DeleteUserByIdAsync(string id)
        {
            var userFromDd = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (userFromDd != null) { 
                dbContext.Users.Remove(userFromDd);
                return await dbContext.SaveChangesAsync() > 0;
            }

            return false;
        }

    }
}
