using MediatR;
using WeatherDashboardAPI.Domain.Entities;
using WeatherDashboardAPI.Domain.Interfaces;

namespace WeatherDashboardAPI.Application.Queries
{
    public record GetFavoriteCityByIdQuery(string FavoriteCityId) : IRequest<FavoriteCitiesEntity>;
    public class GetFavoriteCityByIdQueryHandler(IFavoriteCityRepository favoriteCityRepository)
        : IRequestHandler<GetFavoriteCityByIdQuery, FavoriteCitiesEntity>
    {
        public async Task<FavoriteCitiesEntity> Handle(GetFavoriteCityByIdQuery request, CancellationToken cancellationToken)
        {
            return await favoriteCityRepository.GetFavoriteCityByIdAsync(request.FavoriteCityId);
        }
    }
}
