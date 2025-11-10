using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WeatherDashboardAPI.Controllers;
using WeatherDashboardAPI.Domain.Entities;
using AppCommands = WeatherDashboardAPI.Application.Commands;
using AppQueries = WeatherDashboardAPI.Application.Queries;

namespace WeatherDashboardAPI.UnitTesting
{
    public class UsersControllerTests
    {
        private readonly UsersController _usersController;
        private readonly Mock<IMediator> _mediatorMock;

        public UsersControllerTests() {
            _mediatorMock = new Mock<IMediator>();
            _usersController = new UsersController(_mediatorMock.Object);
        }

        [Fact]
        public async Task GetUserByIdQuery_ReturnsNotFoundResult_WhenNoUserExists()
        {
            // Arrange
            var id = "xxxx";
            _mediatorMock.Setup(m => m.Send(It.IsAny<AppQueries.GetUserByIdQuery>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync((UserEntity)null);

            // Act
            var result = await _usersController.GetUserByIdAsync(id);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundResult>(result);
            Assert.Equal(404,notFoundResult.StatusCode);
        }

        [Fact]
        public async Task GetUserByIdQuery_ReturnsOkResult_WhenUserExists()
        {
            // Arrange
            var id = "690be55a9833df8b2f206bb3";
            var expectedResult = new UserEntity { Id = id, UserName = "Test Item" };
            _mediatorMock.Setup(m => m.Send(It.IsAny<AppQueries.GetUserByIdQuery>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(expectedResult);

            // Act
            var result = await _usersController.GetUserByIdAsync(id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualResult = Assert.IsType<UserEntity>(okResult.Value);
            Assert.Equal(expectedResult.Id, actualResult.Id);
            Assert.Equal(expectedResult.UserName, actualResult.UserName);
        }

        [Fact]
        public async Task GetAllUsersQuery_ReturnsOkResult_WhenNoUserIdRequired()
        {
            // Arrange
            var expectedResult = new List<UserEntity> { 
                new() { Id = "690be55a9833df8b2f206bb3" , UserName = "AdminTest 1" },
                new() { Id = "690be55a9833df8b2f209cb3" , UserName = "AdminTest 2" }
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<AppQueries.GetAllUsersQuery>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(expectedResult);

            // Act
            var result = await _usersController.GetAllUsersAsync();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualItems = Assert.IsAssignableFrom<IEnumerable<UserEntity>>(okResult.Value);
            Assert.Equal(expectedResult.Count, actualItems.Count());
            Assert.Equal(expectedResult.First().UserName, actualItems.First().UserName);
        }

        [Fact]
        public async Task AddUserCommand_ReturnsBadRequestResult_WhenPassingDataInvalid()
        {
            // Arrange
            var createItemRequest = new UserEntity
            {
                Id = "",
                UserName = "FailureUserCreationjsjsjsjsjsjjksksksksksksksksksksksksksksksksksksksksksksksksksksks"
            };
            var expectedResult = new UserEntity { Id = "690be55a9833df8b2f206bb3", UserName = "NewUser" };
            _mediatorMock.Setup(m => m.Send(It.IsAny<AppCommands.AddUserCommand>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(expectedResult);

            _usersController.ModelState.AddModelError("UserName", "User name must be max 50 characters.");

            // Act
            var result = await _usersController.AddUserAsync(createItemRequest);

            // Assert
            var notFoundResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, notFoundResult.StatusCode);
        }

        [Fact]
        public async Task AddUserCommand_ReturnsOkResult_WhenNewUserIsNeeded()
        {
            // Arrange
            var createItemRequest = new UserEntity { Id = "" , UserName = "NewUser" };
            var expectedResult = new UserEntity { Id = "690be55a9833df8b2f206bb3", UserName = "NewUser" };
            _mediatorMock.Setup(m => m.Send(It.IsAny<AppCommands.AddUserCommand>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(expectedResult);

            // Act
            var result = await _usersController.AddUserAsync(createItemRequest);

            // Assert
            Assert.NotNull(result);
            var createdResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(expectedResult, createdResult.Value);
            _mediatorMock.Verify(m => m.Send(It.Is<AppCommands.AddUserCommand>(c => c.User.UserName == expectedResult.UserName), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task UpdateUserCommand_ReturnsOkResult_WhenDataModificationUserIsNeeded()
        {
            // Arrange
            var updateItemRequest = new UserEntity { Id = "690be55a9833df8b2f206bb3", UserName = "UpdateUser" };
            var expectedResult = new UserEntity { Id = "690be55a9833df8b2f206bb3", UserName = "UpdateUser" };
            _mediatorMock.Setup(m => m.Send(It.IsAny<AppCommands.UpdateUserCommand>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(expectedResult);

            // Act
            var result = await _usersController.UpdateUserAsync(updateItemRequest);

            // Assert
            Assert.NotNull(result);
            var createdResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(expectedResult, createdResult.Value);
            _mediatorMock.Verify(m => m.Send(It.Is<AppCommands.UpdateUserCommand>(c => c.UserEntity.UserName == expectedResult.UserName), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task DeleteUserCommand_ReturnsOkResult_WhenDeleteUserIsNeeded()
        {
            // Arrange
            var idUserToDelete = "690be55a9833df8b2f206bb3";
            _mediatorMock.Setup(m => m.Send(It.IsAny<AppCommands.DeleteUserCommand>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(true);

            // Act
            var result = await _usersController.DeleteUserAsync(idUserToDelete);

            // Assert
            Assert.NotNull(result);
            var createdResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(true, createdResult.Value);
            _mediatorMock.Verify(m => m.Send(It.Is<AppCommands.DeleteUserCommand>(c => c.UserId == idUserToDelete), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}