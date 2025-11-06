using MediatR;
using WeatherDashboardAPI.Domain.Entities;
using WeatherDashboardAPI.Domain.Interfaces;

namespace WeatherDashboardAPI.Application.Queries
{
    public record GetWeatherHistoryByIdQuery(string WeatherHistoryId) : IRequest<WeatherHistoryEntity>;

    public class GetWeatherHistoryByIdQueryHandler (IWeatherHistoryRepository weatherHistoryRepository)
        : IRequestHandler<GetWeatherHistoryByIdQuery, WeatherHistoryEntity>
    {
        public async Task<WeatherHistoryEntity> Handle(GetWeatherHistoryByIdQuery request, CancellationToken cancellationToken)
        {
            return await weatherHistoryRepository.GetWeatherHistoryByIdAsync(request.WeatherHistoryId);
        }
    }
}
