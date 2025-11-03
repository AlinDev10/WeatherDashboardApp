using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WeatherDashboardAPI.Infraestructure.Data;

namespace WeatherDashboardAPI.Infraestructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services , string mongoConnectionString, string databaseName)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseMongoDB(mongoConnectionString, databaseName);
            });

            return services;
        }
    }
}
