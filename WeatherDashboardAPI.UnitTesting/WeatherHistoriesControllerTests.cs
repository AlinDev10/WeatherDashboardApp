using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using AppQueries = WeatherDashboardAPI.Application.Queries;
using AppCommands = WeatherDashboardAPI.Application.Commands;
using WeatherDashboardAPI.Controllers;

namespace WeatherDashboardAPI.UnitTesting {
    public class WeatherHistoriesControllerTests
    {
        private readonly WeatherHistoriesController _weatherHistoriesController;
        private readonly Mock<IMediator> _mediatorMock;

        public WeatherHistoriesControllerTests() 
        {
            _mediatorMock = new Mock<IMediator>();
            _weatherHistoriesController = new WeatherHistoriesController(_mediatorMock.Object);
        }

        [Fact]
        public void Test1()
        {
           
        }
    }
}


