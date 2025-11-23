using Kaloom.API.Controllers;
using Kaloom.Application.Facades;
using Kaloom.Application.UseCases.Etecs.GetAll;
using Kaloom.Application.UseCases.Etecs.GetById;
using Kaloom.Application.UseCases.Students.GetById;
using Kaloom.Communication.DTOs.Responses;
using Kaloom.Exceptions.ExceptionsBase;
using Kaloom.Tests.MockData;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;

namespace Kaloom.Tests.Controllers
{
    public class EtecControllerTests
    {
        private readonly Mock<IEtecFacade> _mockFacade;
        private readonly EtecController _controller;

        public EtecControllerTests()
        {
            this._mockFacade = new Mock<IEtecFacade>();
            this._controller = new EtecController(_mockFacade.Object);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsOk_WithEtecList()
        {
            _mockFacade.Setup(f => f.GetAll.ExecuteAsync())
                .ReturnsAsync(EtecMockData.GetAll());

            var result = await _controller.GetAllAsync();

            var resultOk = Assert.IsType<OkObjectResult>(result);
            var resultEtecs = Assert.IsAssignableFrom<IEnumerable<EtecResponse>>(resultOk.Value);

            Assert.Equal(2, resultEtecs.Count());
        }

        [Fact]
        public async Task GetAllEtecsAsync_ShouldReturn200Status()
        {
            var getAllMock = new Mock<IGetAllEtecsUseCase>();
            getAllMock.Setup(_ => _.ExecuteAsync())
                .ReturnsAsync(EtecMockData.GetAll());

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
        public async Task GetEtecByIdAsync_ShouldReturn200Status(int id)
        {
            var getByIdMock = new Mock<IGetEtecByIdUseCase>();
            getByIdMock.Setup(_ => _.ExecuteAsync(id))
                .ReturnsAsync(EtecMockData.GetById(id));

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
            var getByIdMock = new Mock<IGetEtecByIdUseCase>();

            getByIdMock.Setup(_ => _.ExecuteAsync(id))
                .ThrowsAsync(new NotFoundException($"Etec com ID {id} não encontrada."));

            _mockFacade.SetupGet(f => f.GetById)
                .Returns(getByIdMock.Object);

            var exception = await Assert.ThrowsAsync<NotFoundException>(() => _controller.GetByIdAsync(id));

            Assert.Equal($"Etec com ID {id} não encontrada.", exception.Message);
        }

        [Fact]
        public async Task RegisterEtecAsync_ShouldReturnCreated_WithResponse()
        {
            var request = EtecMockData.RegisterRequest();

            _mockFacade.Setup(f => f.Register.ExecuteAsync(request))
                .ReturnsAsync(EtecMockData.RegisterResponse());

            var result = await _controller.CreateAsync(request);

            var createdResult = Assert.IsType<CreatedAtRouteResult>(result);
            Assert.Equal("GetEtecById", createdResult.RouteName);

            var etec = Assert.IsType<EtecResponse>(createdResult.Value);
            Assert.Equal(1, etec.Id);
        }

        [Fact]
        public async Task UpdateEtecAsync_ShouldReturnNoContent()
        {
            var request = EtecMockData.UpdateRequest("Etec JK");

            _mockFacade.Setup(f => f.Update.ExecuteAsync(1, request))
                       .Returns(Task.CompletedTask);

            var result = await _controller.UpdateAsync(1, request);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteEtecAsync_ShouldReturnNoContent()
        {
            _mockFacade.Setup(f => f.Delete.ExecuteAsync(1))
                       .Returns(Task.CompletedTask);

            var result = await _controller.DeleteAsync(1);

            Assert.IsType<NoContentResult>(result);
        }
    }
}
