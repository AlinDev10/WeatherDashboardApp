using MediatR;
using WeatherDashboardAPI.Domain.Interfaces;

namespace WeatherDashboardAPI.Application.Commands
{
    public record DeleteWeatherHistoryCommand(string WeatherHistoryId) : IRequest<bool>;
    public class DeleteWeatherHistoryCommandHandler(IWeatherHistoryRepository weatherHistoryRepository)
        : IRequestHandler<DeleteWeatherHistoryCommand, bool>
    {
        public async Task<bool> Handle(DeleteWeatherHistoryCommand request, CancellationToken cancellationToken)
        {
            return await weatherHistoryRepository.DeleteWeatherHistoryByIdAsync(request.WeatherHistoryId);
        }
    }
}
