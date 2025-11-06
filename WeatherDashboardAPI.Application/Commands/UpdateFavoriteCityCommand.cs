using MediatR;
using WeatherDashboardAPI.Domain.Entities;
using WeatherDashboardAPI.Domain.Interfaces;

namespace WeatherDashboardAPI.Application.Commands
{
    public record UpdateFavoriteCityCommand(FavoriteCitiesEntity FavoriteCitiesEntity) : IRequest<FavoriteCitiesEntity>;
    public class UpdateFavoriteCityCommandHandler(IFavoriteCityRepository favoriteCityRepository)
        : IRequestHandler<UpdateFavoriteCityCommand, FavoriteCitiesEntity>
    {
        public async Task<FavoriteCitiesEntity> Handle(UpdateFavoriteCityCommand request, CancellationToken cancellationToken)
        {
            return await favoriteCityRepository.UpdateFavoriteCityAsync(request.FavoriteCitiesEntity);
        }
    }
}
