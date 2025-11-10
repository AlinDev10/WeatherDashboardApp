using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using AppQueries = WeatherDashboardAPI.Application.Queries;
using AppCommands = WeatherDashboardAPI.Application.Commands;
using WeatherDashboardAPI.Controllers;

namespace WeatherDashboardAPI.UnitTesting
{
    public class FavoriteCitiesControllerTests
    {
        private readonly FavoriteCitiesController _favoriteCitiesController;
        private readonly Mock<IMediator> _mediatorMock;

        public FavoriteCitiesControllerTests() {
            _mediatorMock = new Mock<IMediator>();
            _favoriteCitiesController = new FavoriteCitiesController(_mediatorMock.Object);
        }

        [Fact]
        public void Test1()
        {

        }
    }
}
