using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WeatherDashboardAPI.Controllers;
using WeatherDashboardAPI.Domain.Entities;
using AppCommands = WeatherDashboardAPI.Application.Commands;
using AppQueries = WeatherDashboardAPI.Application.Queries;

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
        public async Task GetFavoriteCityByIdAsync_ReturnsNotFoundResult_WhenNoFavoriteCityExists()
        {
            // Arrange
            var id = "xxxx";
            _mediatorMock.Setup(m => m.Send(It.IsAny<AppQueries.GetFavoriteCityByIdQuery>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync((FavoriteCitiesEntity)null);

            // Act
            var result = await _favoriteCitiesController.GetFavoriteCityByIdAsync(id);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundResult>(result);
            Assert.Equal(404, notFoundResult.StatusCode);
        }

        [Fact]
        public async Task GetFavoriteCityByIdAsync_ReturnsOkResult_WhenFavoriteCityExists()
        {
            // Arrange
            var id = "690be55a9833df8b2f206bb3";
            var expectedResult = new FavoriteCitiesEntity { 
                Id = id,  CityName = "City test", CountryCode = "MX", UserId = "690be55a9833df8b2f206bb3", 
                AddedAt = new DateTime()};
            _mediatorMock.Setup(m => m.Send(It.IsAny<AppQueries.GetFavoriteCityByIdQuery>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(expectedResult);

            // Act
            var result = await _favoriteCitiesController.GetFavoriteCityByIdAsync(id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualResult = Assert.IsType<FavoriteCitiesEntity>(okResult.Value);
            Assert.Equal(expectedResult.Id, actualResult.Id);
            Assert.Equal(expectedResult.CityName, actualResult.CityName);
        }

        [Fact]
        public async Task GetAllFavoriteCitiesAsync_ReturnsOkResult_WhenNoFavoriteCityIdRequired()
        {
            // Arrange
            var expectedResult = new List<FavoriteCitiesEntity> {
                new() { Id = "690be55a9833df8b2f209cb3",  CityName = "City Test", CountryCode = "MX", UserId = "690be55a9833df8b2f206bb3",
                AddedAt = new DateTime() },
                new() { Id = "690be55a3833df8b2f209cb3",  CityName = "City Test 2", CountryCode = "MX", UserId = "690be55a9833df8b2f206bb3",
                AddedAt = new DateTime() }
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<AppQueries.GetAllFavoriteCitiesQuery>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(expectedResult);

            // Act
            var result = await _favoriteCitiesController.GetAllFavoriteCitiesAsync();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualItems = Assert.IsAssignableFrom<IEnumerable<FavoriteCitiesEntity>>(okResult.Value);
            Assert.Equal(expectedResult.Count, actualItems.Count());
            Assert.Equal(expectedResult.First().CityName, actualItems.First().CityName);
        }

        [Fact]
        public async Task AddFavoriteCityAsync_ReturnsBadRequestResult_WhenPassingDataInvalid()
        {
            // Arrange
            var createItemRequest = new FavoriteCitiesEntity
            {
                Id = "",
                CityName = "Mexico",
                CountryCode = "MXXXXX",
                AddedAt = new DateTime(),
                UserId = "690be55a9833af8b2f266bb3"
            };
            var expectedResult = new FavoriteCitiesEntity { Id = "690be55a9833df8b2f206bb3",
                CityName = "Mexico",
                CountryCode = "MXXXXX",
                AddedAt = new DateTime(),
                UserId = "690be55a9833af8b2f266bb3"
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<AppCommands.AddFavoriteCityCommand>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(expectedResult);

            _favoriteCitiesController.ModelState.AddModelError("CountryCode", "Country Code must be max 2 characters.");

            // Act
            var result = await _favoriteCitiesController.AddFavoriteCityAsync(createItemRequest);

            // Assert
            var notFoundResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, notFoundResult.StatusCode);
        }

        [Fact]
        public async Task AddFavoriteCityAsync_ReturnsOkResult_WhenNewFavoriteCityIsNeeded()
        {
            // Arrange
            var createItemRequest = new FavoriteCitiesEntity
            {
                Id = "",
                CityName = "Mexico",
                CountryCode = "MX",
                AddedAt = new DateTime(),
                UserId = "690be55a9833af8b2f266bb3"
            };
            var expectedResult = new FavoriteCitiesEntity
            {
                Id = "690be55a9833df8b2f206bb3",
                CityName = "Mexico",
                CountryCode = "MX",
                AddedAt = new DateTime(),
                UserId = "690be55a9833af8b2f266bb3"
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<AppCommands.AddFavoriteCityCommand>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(expectedResult);

            // Act
            var result = await _favoriteCitiesController.AddFavoriteCityAsync(createItemRequest);

            // Assert
            Assert.NotNull(result);
            var createdResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(expectedResult, createdResult.Value);
            _mediatorMock.Verify(m => m.Send(It.Is<AppCommands.AddFavoriteCityCommand>(c => c.FavoriteCity.CityName == expectedResult.CityName), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task UpdateFavoriteCityAsync_ReturnsOkResult_WhenDataModificationFavoriteCityIsNeeded()
        {
            // Arrange
            var updateItemRequest = new FavoriteCitiesEntity
            {
                Id = "690be55a9833df8b2f206bb3",
                CityName = "Mexico",
                CountryCode = "MX",
                AddedAt = new DateTime(),
                UserId = "690be55a9833af8b2f266bb3"
            };
            var expectedResult = new FavoriteCitiesEntity
            {
                Id = "690be55a9833df8b2f206bb3",
                CityName = "Mexico",
                CountryCode = "MX",
                AddedAt = new DateTime(),
                UserId = "690be55a9833af8b2f266bb3"
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<AppCommands.UpdateFavoriteCityCommand>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(expectedResult);

            // Act
            var result = await _favoriteCitiesController.UpdateFavoriteCityAsync(updateItemRequest);

            // Assert
            Assert.NotNull(result);
            var createdResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(expectedResult, createdResult.Value);
            _mediatorMock.Verify(m => m.Send(It.Is<AppCommands.UpdateFavoriteCityCommand>(c => c.FavoriteCitiesEntity.CityName == expectedResult.CityName), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task DeleteFavoriteCityAsync_ReturnsOkResult_WhenDeleteFavoriteCityIsNeeded()
        {
            // Arrange
            var idFavoriteCityToDelete = "690be55a9833df8b2f206bb3";
            _mediatorMock.Setup(m => m.Send(It.IsAny<AppCommands.DeleteFavoriteCityCommand>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(true);

            // Act
            var result = await _favoriteCitiesController.DeleteFavoriteCityAsync(idFavoriteCityToDelete);

            // Assert
            Assert.NotNull(result);
            var createdResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(true, createdResult.Value);
            _mediatorMock.Verify(m => m.Send(It.Is<AppCommands.DeleteFavoriteCityCommand>(c => c.FavoriteCityId == idFavoriteCityToDelete), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
