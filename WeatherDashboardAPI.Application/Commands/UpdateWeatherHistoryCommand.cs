using MediatR;
using WeatherDashboardAPI.Domain.Entities;
using WeatherDashboardAPI.Domain.Interfaces;

namespace WeatherDashboardAPI.Application.Commands
{
    public record UpdateWeatherHistoryCommand(WeatherHistoryEntity WeatherHistoryEntity) : IRequest<WeatherHistoryEntity>;
    public class UpdateWeatherHistoryCommandHandler(IWeatherHistoryRepository weatherHistoryRepository)
        : IRequestHandler<UpdateWeatherHistoryCommand, WeatherHistoryEntity>
    {
        public async Task<WeatherHistoryEntity> Handle(UpdateWeatherHistoryCommand request, CancellationToken cancellationToken)
        {
            return await weatherHistoryRepository.UpdateWeatherHistoryAsync(request.WeatherHistoryEntity);
        }
    }
}
