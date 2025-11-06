using MediatR;
using WeatherDashboardAPI.Domain.Interfaces;

namespace WeatherDashboardAPI.Application.Commands
{
    public record DeleteFavoriteCityCommand(string FavoriteCityId) : IRequest<bool>;
    public class DeleteFavoriteCityCommandHandler(IFavoriteCityRepository favoriteCityRepository)
        : IRequestHandler<DeleteFavoriteCityCommand, bool>
    {
        public async Task<bool> Handle(DeleteFavoriteCityCommand request, CancellationToken cancellationToken)
        {
            return await favoriteCityRepository.DeleteFavoriteCityByIdAsync(request.FavoriteCityId);
        }
    }
}
