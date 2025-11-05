using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using WeatherDashboardAPI.Domain.Interfaces;
using WeatherDashboardAPI.Domain.Models;
using WeatherDashboardAPI.Infraestructure.Data;
using WeatherDashboardAPI.Infraestructure.Repositories;

namespace WeatherDashboardAPI.Infraestructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>((provider, options) =>
            {
                options.UseMongoDB(provider.GetRequiredService<IOptionsSnapshot<MongoDBSettings>>().Value.ConnectionString
                                   , provider.GetRequiredService<IOptionsSnapshot<MongoDBSettings>>().Value.DatabaseName);
            });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IWeatherHistoryRepository, WeatherHistoryRepository>();
            services.AddScoped<IFavoriteCityRepository, FavoriteCityRepository>();

            return services;
        }
    }
}
