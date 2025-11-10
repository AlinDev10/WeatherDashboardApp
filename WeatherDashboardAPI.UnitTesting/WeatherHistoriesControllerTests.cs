using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WeatherDashboardAPI.Controllers;
using WeatherDashboardAPI.Domain.Entities;
using AppCommands = WeatherDashboardAPI.Application.Commands;
using AppQueries = WeatherDashboardAPI.Application.Queries;

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
        public async Task GetWeatherHistoryByIdAsync_ReturnsNotFoundResult_WhenNoWeatherHistoryExists()
        {
            // Arrange
            var id = "xxxx";
            _mediatorMock.Setup(m => m.Send(It.IsAny<AppQueries.GetWeatherHistoryByIdQuery>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync((WeatherHistoryEntity)null);

            // Act
            var result = await _weatherHistoriesController.GetWeatherHistoryByIdAsync(id);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundResult>(result);
            Assert.Equal(404, notFoundResult.StatusCode);
        }

        [Fact]
        public async Task GetWeatherHistoryByIdAsync_ReturnsOkResult_WhenWeatherHistoryExists()
        {
            // Arrange
            var id = "690be55a9833df8b2f206bb3";
            var expectedResult = new WeatherHistoryEntity
            {
                Id = id,
                CityName = "City test",
                CountryCode = "MX",
                UserId = "690be55a9833df8b2f206bb3",
                SearchedAt = new DateTime(),
                WeatherData = "JSON string"
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<AppQueries.GetWeatherHistoryByIdQuery>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(expectedResult);

            // Act
            var result = await _weatherHistoriesController.GetWeatherHistoryByIdAsync(id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualResult = Assert.IsType<WeatherHistoryEntity>(okResult.Value);
            Assert.Equal(expectedResult.Id, actualResult.Id);
            Assert.Equal(expectedResult.CityName, actualResult.CityName);
        }

        [Fact]
        public async Task GetAllWeatherHistoriesAsync_ReturnsOkResult_WhenNoWeatherHistoryIdRequired()
        {
            // Arrange
            var expectedResult = new List<WeatherHistoryEntity> {
                new() { Id = "690be55a9833df8b2f209cb3",  CityName = "City Test", CountryCode = "MX", UserId = "690be55a9833df8b2f206bb3",
                SearchedAt = new DateTime(), WeatherData = "JSON string" },
                new() { Id = "690be55a3833df8b2f209cb3",  CityName = "City Test 2", CountryCode = "MX", UserId = "690be55a9833df8b2f206bb3",
                SearchedAt = new DateTime(), WeatherData = "JSON string"  }
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<AppQueries.GetAllWeatherHistoriesQuery>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(expectedResult);

            // Act
            var result = await _weatherHistoriesController.GetAllWeatherHistoriesAsync();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualItems = Assert.IsAssignableFrom<IEnumerable<WeatherHistoryEntity>>(okResult.Value);
            Assert.Equal(expectedResult.Count, actualItems.Count());
            Assert.Equal(expectedResult.First().CityName, actualItems.First().CityName);
        }

        [Fact]
        public async Task AddWeatherHistoryAsync_ReturnsBadRequestResult_WhenPassingDataInvalid()
        {
            // Arrange
            var createItemRequest = new WeatherHistoryEntity
            {
                Id = "",
                CityName = "Mexico",
                CountryCode = "MXXXXX",
                SearchedAt = new DateTime(),
                UserId = "690be55a9833af8b2f266bb3",
                WeatherData = "JSOn string"
            };
            var expectedResult = new WeatherHistoryEntity
            {
                Id = "690be55a9833df8b2f206bb3",
                CityName = "Mexico",
                CountryCode = "MXXXXX",
                SearchedAt = new DateTime(),
                UserId = "690be55a9833af8b2f266bb3",
                WeatherData = "JSOn string"
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<AppCommands.AddWeatherHistoryCommand>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(expectedResult);

            _weatherHistoriesController.ModelState.AddModelError("CountryCode", "Country Code must be max 2 characters.");

            // Act
            var result = await _weatherHistoriesController.AddWeatherHistoryAsync(createItemRequest);

            // Assert
            var notFoundResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, notFoundResult.StatusCode);
        }

        [Fact]
        public async Task AddWeatherHistoryAsync_ReturnsOkResult_WhenNewWeatherHistoryIsNeeded()
        {
            // Arrange
            var createItemRequest = new WeatherHistoryEntity
            {
                Id = "",
                CityName = "Mexico",
                CountryCode = "MX",
                SearchedAt = new DateTime(),
                UserId = "690be55a9833af8b2f266bb3",
                WeatherData = "JSOn string" 
            };
            var expectedResult = new WeatherHistoryEntity
            {
                Id = "690be55a9833df8b2f206bb3",
                CityName = "Mexico",
                CountryCode = "MX",
                SearchedAt = new DateTime(),
                UserId = "690be55a9833af8b2f266bb3",
                WeatherData = "JSOn string"
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<AppCommands.AddWeatherHistoryCommand>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(expectedResult);

            // Act
            var result = await _weatherHistoriesController.AddWeatherHistoryAsync(createItemRequest);

            // Assert
            Assert.NotNull(result);
            var createdResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(expectedResult, createdResult.Value);
            _mediatorMock.Verify(m => m.Send(It.Is<AppCommands.AddWeatherHistoryCommand>(c => c.WeatherHistory.CityName == expectedResult.CityName), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task UpdateWeatherHistoryAsync_ReturnsOkResult_WhenDataModificationWeatherHistoryIsNeeded()
        {
            // Arrange
            var updateItemRequest = new WeatherHistoryEntity
            {
                Id = "690be55a9833df8b2f206bb3",
                CityName = "Mexico",
                CountryCode = "MX",
                SearchedAt = new DateTime(),
                UserId = "690be55a9833af8b2f266bb3",
                WeatherData = "JSON string"
            };
            var expectedResult = new WeatherHistoryEntity
            {
                Id = "690be55a9833df8b2f206bb3",
                CityName = "Mexico",
                CountryCode = "MX",
                SearchedAt = new DateTime(),
                UserId = "690be55a9833af8b2f266bb3",
                WeatherData = "JSON string"
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<AppCommands.UpdateWeatherHistoryCommand>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(expectedResult);

            // Act
            var result = await _weatherHistoriesController.UpdateWeatherHistoryAsync(updateItemRequest);

            // Assert
            Assert.NotNull(result);
            var createdResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(expectedResult, createdResult.Value);
            _mediatorMock.Verify(m => m.Send(It.Is<AppCommands.UpdateWeatherHistoryCommand>(c => c.WeatherHistoryEntity.CityName == expectedResult.CityName), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task DeleteWeatherHistoryAsync_ReturnsOkResult_WhenDeleteWeatherHistoryIsNeeded()
        {
            // Arrange
            var idWeatherHistoryIdToDelete = "690be55a9833df8b2f206bb3";
            _mediatorMock.Setup(m => m.Send(It.IsAny<AppCommands.DeleteWeatherHistoryCommand>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(true);

            // Act
            var result = await _weatherHistoriesController.DeleteWeatherHistoryAsync(idWeatherHistoryIdToDelete);

            // Assert
            Assert.NotNull(result);
            var createdResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(true, createdResult.Value);
            _mediatorMock.Verify(m => m.Send(It.Is<AppCommands.DeleteWeatherHistoryCommand>(c => c.WeatherHistoryId == idWeatherHistoryIdToDelete), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}


