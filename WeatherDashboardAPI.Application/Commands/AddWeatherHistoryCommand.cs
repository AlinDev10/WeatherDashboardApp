using MediatR;
using WeatherDashboardAPI.Domain.Entities;
using WeatherDashboardAPI.Domain.Interfaces;

namespace WeatherDashboardAPI.Application.Commands
{
    public record AddWeatherHistoryCommand(WeatherHistoryEntity WeatherHistory) : IRequest<WeatherHistoryEntity>;
    public class AddWeatherHistoryCommandHandler(IWeatherHistoryRepository weatherHistoryRepository)
        : IRequestHandler<AddWeatherHistoryCommand, WeatherHistoryEntity>
    {
        public async Task<WeatherHistoryEntity> Handle(AddWeatherHistoryCommand request, CancellationToken cancellationToken)
        {
            return await weatherHistoryRepository.AddWeatherHistoryAsync(request.WeatherHistory);
        }
    }
}
