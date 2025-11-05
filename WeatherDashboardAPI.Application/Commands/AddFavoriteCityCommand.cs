using MediatR;
using WeatherDashboardAPI.Domain.Entities;
using WeatherDashboardAPI.Domain.Interfaces;

namespace WeatherDashboardAPI.Application.Commands
{
    public record AddFavoriteCityCommand(FavoriteCitiesEntity FavoriteCity) : IRequest<FavoriteCitiesEntity>;
    public class AddFavoriteCityCommandHandler(IFavoriteCityRepository favoriteCityRepository)
        : IRequestHandler<AddFavoriteCityCommand, FavoriteCitiesEntity>
    {
        public async Task<FavoriteCitiesEntity> Handle(AddFavoriteCityCommand request, CancellationToken cancellationToken)
        {
            return await favoriteCityRepository.AddFavoriteCityAsync(request.FavoriteCity);
        }
    }
}
