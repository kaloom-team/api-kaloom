using Kaloom.API.Controllers;
using Kaloom.Application.Facades;
using Kaloom.Application.UseCases.Etecs.GetById;
using Kaloom.Application.UseCases.Fatecs.GetAll;
using Kaloom.Application.UseCases.Fatecs.GetById;
using Kaloom.Communication.DTOs.Responses;
using Kaloom.Exceptions.ExceptionsBase;
using Kaloom.Tests.MockData;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;

namespace Kaloom.Tests.Controllers
{
    public class FatecControllerTests
    {
        private readonly Mock<IFatecFacade> _mockFacade;
        private readonly FatecController _controller;

        public FatecControllerTests()
        {
            this._mockFacade = new Mock<IFatecFacade>();
            this._controller = new FatecController(_mockFacade.Object);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsOk_WithFatecList()
        {
            _mockFacade.Setup(f => f.GetAll.ExecuteAsync())
                .ReturnsAsync(FatecMockData.GetAll());

            var result = await _controller.GetAllAsync();

            var resultOk = Assert.IsType<OkObjectResult>(result);
            var returnFatecs = Assert.IsAssignableFrom<IEnumerable<FatecResponse>>(resultOk.Value);

            Assert.Equal(2, returnFatecs.Count());
        }

        [Fact]
        public async Task GetAllFatecsAsync_ShouldReturn200Status()
        {
            var getAllMock = new Mock<IGetAllFatecsUseCase>();
            getAllMock.Setup(_ => _.ExecuteAsync())
                .ReturnsAsync(FatecMockData.GetAll());

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
        public async Task GetFatecByIdAsync_ShouldReturn200Status(int id)
        {
            var getByIdMock = new Mock<IGetFatecByIdUseCase>();
            getByIdMock.Setup(_ => _.ExecuteAsync(id))
                .ReturnsAsync(FatecMockData.GetById(id));

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
        public async Task GetEtecByIdAsync_ShouldReturns404Status(int id)
        {
            var getByIdMock = new Mock<IGetFatecByIdUseCase>();

            getByIdMock.Setup(_ => _.ExecuteAsync(id))
                .ThrowsAsync(new NotFoundException($"Fatec com ID {id} não encontrada."));

            _mockFacade.SetupGet(f => f.GetById)
                .Returns(getByIdMock.Object);

            var exception = await Assert.ThrowsAsync<NotFoundException>(() => _controller.GetByIdAsync(id));

            Assert.Equal($"Fatec com ID {id} não encontrada.", exception.Message);
        }

        [Fact]
        public async Task RegisterFatecAsync_ShouldReturnCreated_WithResponse()
        {
            var request = FatecMockData.RegisterRequest();

            _mockFacade.Setup(f => f.Register.ExecuteAsync(request))
                .ReturnsAsync(FatecMockData.RegisterResponse());

            var result = await _controller.CreateAsync(request);

            var createdResult = Assert.IsType<CreatedAtRouteResult>(result);
            Assert.Equal("GetFatecById", createdResult.RouteName);

            var returnFatec = Assert.IsType<FatecResponse>(createdResult.Value);
            Assert.Equal(1, returnFatec.Id);
        }

        [Fact]
        public async Task UpdateFatecAsync_ShouldReturnNoContent()
        {
            var request = FatecMockData.UpdateRequest("Fatec atualizada");

            _mockFacade.Setup(f => f.Update.ExecuteAsync(1, request))
                       .Returns(Task.CompletedTask);

            var result = await _controller.UpdateAsync(1, request);
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnNoContent()
        {
            _mockFacade.Setup(f => f.Delete.ExecuteAsync(1))
                       .Returns(Task.CompletedTask);

            var result = await _controller.DeleteAsync(1);
            Assert.IsType<NoContentResult>(result);
        }
    }
}
