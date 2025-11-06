using MediatR;
using WeatherDashboardAPI.Domain.Entities;
using WeatherDashboardAPI.Domain.Interfaces;

namespace WeatherDashboardAPI.Application.Queries
{
    public record GetAllWeatherHistoriesQuery() : IRequest<IEnumerable<WeatherHistoryEntity>>;
    public class GetAllWeatherHistoriesQueryHandler(IWeatherHistoryRepository weatherHistoryRepository)
        : IRequestHandler<GetAllWeatherHistoriesQuery, IEnumerable<WeatherHistoryEntity>>
    {
        public async Task<IEnumerable<WeatherHistoryEntity>> Handle(GetAllWeatherHistoriesQuery request, CancellationToken cancellationToken)
        {
            return await weatherHistoryRepository.GetWeatherHistoriesAsync();
        }
    }
}
