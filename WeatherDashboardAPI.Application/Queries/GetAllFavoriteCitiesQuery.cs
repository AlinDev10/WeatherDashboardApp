using MediatR;
using WeatherDashboardAPI.Domain.Entities;
using WeatherDashboardAPI.Domain.Interfaces;

namespace WeatherDashboardAPI.Application.Queries
{
    public record GetAllFavoriteCitiesQuery() : IRequest<IEnumerable<FavoriteCitiesEntity>>;
    public class GetAllFavoriteCitiesQueryHandler(IFavoriteCityRepository favoriteCityRepository)
        : IRequestHandler<GetAllFavoriteCitiesQuery, IEnumerable<FavoriteCitiesEntity>>
    {
        public async Task<IEnumerable<FavoriteCitiesEntity>> Handle(GetAllFavoriteCitiesQuery request, CancellationToken cancellationToken)
        {
            return await favoriteCityRepository.GetFavoriteCitiesAsync();
        }
    }
}
