using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;
using WeatherDashboardAPI.Domain.Entities;

namespace WeatherDashboardAPI.Infraestructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
        : base(options)
        {
        }

        public DbSet<UserEntity> Users { get; init; }

        public DbSet<WeatherHistoryEntity> WeatherHistory { get; init; }

        public DbSet<FavoriteCitiesEntity> FavoriteCities { get; init; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>().ToCollection("users");
            modelBuilder.Entity<WeatherHistoryEntity>().ToCollection("weather_history");
            modelBuilder.Entity<FavoriteCitiesEntity>().ToCollection("favorite_cities");
        }
    }
}
