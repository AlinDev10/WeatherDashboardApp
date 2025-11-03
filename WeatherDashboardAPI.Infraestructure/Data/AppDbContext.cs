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

        public DbSet<Users> Users { get; init; }

        public DbSet<WeatherHistory> WeatherHistory { get; init; }

        public DbSet<FavoriteCities> FavoriteCities { get; init; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Users>().ToCollection("users");
            modelBuilder.Entity<WeatherHistory>().ToCollection("weather_history");
            modelBuilder.Entity<FavoriteCities>().ToCollection("favorite_cities");
        }
    }
}
