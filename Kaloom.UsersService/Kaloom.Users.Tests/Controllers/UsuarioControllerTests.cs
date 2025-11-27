using Kaloom.Users.API.Controllers;
using Kaloom.Users.Application.Facades;
using Kaloom.Users.Application.UseCases.Users.GetAll;
using Kaloom.Users.Application.UseCases.Users.GetById;
using Kaloom.Users.Communication.DTOs.Responses;
using Kaloom.Users.Exceptions.ExceptionsBase;
using Kaloom.Users.Tests.MockData;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;

namespace Kaloom.Users.Tests.Controllers
{
    public class UsuarioControllerTests
    {
        private readonly Mock<IUserFacade> _mockFacade;
        private readonly UsuarioController _controller;

        public UsuarioControllerTests()
        {
            this._mockFacade = new Mock<IUserFacade>();
            this._controller = new UsuarioController(_mockFacade.Object);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsOkResult_WithListOfUsers()
        {
            _mockFacade.Setup(f => f.GetAll.ExecuteAsync())
                .ReturnsAsync(UsuarioMockData.GetAll());

            var result = await _controller.GetAllAsync();

            var resultOk = Assert.IsType<OkObjectResult>(result);
            var returnUsers = Assert.IsAssignableFrom<IEnumerable<UserResponse>>(resultOk.Value);
            Assert.Equal(2, returnUsers.Count());
        }


        [Fact]
        public async Task GetAllUsersAsync_ShouldReturn200Status()
        {
            var getAllMock = new Mock<IGetAllUsersUseCase>();
            getAllMock.Setup(_ => _.ExecuteAsync())
                .ReturnsAsync(UsuarioMockData.GetAll());

            _mockFacade.SetupGet(f => f.GetAll)
                .Returns(getAllMock.Object);

            var result = await _controller.GetAllAsync();

            var resultOk = Assert.IsType<OkObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, resultOk.StatusCode);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public async Task GetUserByIdAsync_ShouldReturns200Status(int id)
        {
            var getByIdMock = new Mock<IGetUserByIdUseCase>();
            getByIdMock.Setup(_ => _.ExecuteAsync(id))
                .ReturnsAsync(UsuarioMockData.GetById(id));

            _mockFacade.SetupGet(f => f.GetById)
                .Returns(getByIdMock.Object);

            var result = await _controller.GetByIdAsync(id);
            var resultOk = Assert.IsType<OkObjectResult>(result);

            Assert.Equal((int)HttpStatusCode.OK, resultOk.StatusCode);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public async Task GetUserByIdAsync_ShouldReturns404Status(int id)
        {
            var getByIdMock = new Mock<IGetUserByIdUseCase>();

            getByIdMock.Setup(_ => _.ExecuteAsync(id))
                .ThrowsAsync(new NotFoundException($"Usuário com ID {id} não encontrada."));

            _mockFacade.SetupGet(f => f.GetById)
                .Returns(getByIdMock.Object);

            var exception = await Assert.ThrowsAsync<NotFoundException>(() => _controller.GetByIdAsync(id));

            Assert.Equal($"Usuário com ID {id} não encontrada.", exception.Message);
        }

        [Fact]
        public async Task RegisterUserAsync_ReturnsCreatedResult_WithUserResponse()
        {
            var request = UsuarioMockData.RegisterRequest();
            _mockFacade.Setup(f => f.Register.ExecuteAsync(request))
                .ReturnsAsync(UsuarioMockData.RegisterResponse());

            var result = await _controller.CreateAsync(request);

            var createdResult = Assert.IsType<CreatedAtRouteResult>(result);
            Assert.Equal("GetUserById", createdResult.RouteName);
            var returnUser = Assert.IsType<UserResponse>(createdResult.Value);
            Assert.Equal(1, returnUser.Id);
        }

        [Fact]
        public async Task UpdateUserAsync_ReturnsNoContent()
        {
            var request = UsuarioMockData.UpdateRequest("email@email.com", "123");

            _mockFacade.Setup(f => f.Update.ExecuteAsync(1, request))
                       .Returns(Task.CompletedTask);

            var result = await _controller.UpdateAsync(1, request);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteUserAsync_ReturnsNoContent()
        {
            _mockFacade.Setup(f => f.Delete.ExecuteAsync(1))
                       .Returns(Task.CompletedTask);

            var result = await _controller.DeleteAsync(1);

            Assert.IsType<NoContentResult>(result);
        }
    }
}
