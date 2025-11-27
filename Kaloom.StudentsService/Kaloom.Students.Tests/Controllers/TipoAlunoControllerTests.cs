using Kaloom.Students.API.Controllers;
using Kaloom.Students.Application.Facades;
using Kaloom.Students.Application.UseCases.StudentsTypes.GetAll;
using Kaloom.Students.Application.UseCases.StudentsTypes.GetById;
using Kaloom.Students.Communication.DTOs.Responses;
using Kaloom.Students.Tests.MockData;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;

namespace Kaloom.Students.Tests.Controllers
{
    public class TipoAlunoControllerTests
    {
        private readonly Mock<IStudentTypeFacade> _mockFacade;
        private readonly TipoAlunoController _controller;

        public TipoAlunoControllerTests()
        {
            this._mockFacade = new Mock<IStudentTypeFacade>();
            this._controller = new TipoAlunoController(_mockFacade.Object);

        }

        [Fact]
        public async Task GetAllAsync_ReturnsOk_WithStudentTypeList()
        {
            var getAllMock = new Mock<IGetAllStudentsTypesUseCase>();
            getAllMock.Setup(_ => _.ExecuteAsync())
                .ReturnsAsync(StudentTypeMockData.GetAll().ToList());

            _mockFacade.SetupGet(f => f.GetAll)
                .Returns(getAllMock.Object);

            var result = await _controller.GetAllAsync();

            var resultOk = Assert.IsType<OkObjectResult>(result);
            var returnTypes = Assert.IsAssignableFrom<IEnumerable<StudentTypeResponse>>(resultOk.Value);

            Assert.Equal(2, returnTypes.Count());
        }

        [Fact]
        public async Task GetAllStudentTypesAsync_ShouldReturn200Status()
        {
            var getAllMock = new Mock<IGetAllStudentsTypesUseCase>();
            getAllMock.Setup(_ => _.ExecuteAsync())
                .ReturnsAsync(StudentTypeMockData.GetAll().ToList());

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
        public async Task GetStudentTypeByIdAsync_ShouldReturn200Status(int id)
        {
            var getByIdMock = new Mock<IGetStudentTypeByIdUseCase>();
            getByIdMock.Setup(_ => _.ExecuteAsync(id))
                .ReturnsAsync(StudentTypeMockData.GetById(id));

            _mockFacade.SetupGet(f => f.GetById)
                .Returns(getByIdMock.Object);

            var result = await _controller.GetByIdAsync(id);
            var resultOk = Assert.IsType<OkObjectResult>(result);

            Assert.Equal((int)HttpStatusCode.OK, resultOk.StatusCode);
        }

        [Fact]
        public async Task RegisterStudentTypeAsync_ShouldReturnCreated_WithResponse()
        {
            var request = StudentTypeMockData.RegisterRequest();

            _mockFacade.Setup(f => f.Register.ExecuteAsync(request))
                .ReturnsAsync(StudentTypeMockData.RegisterResponse());

            var result = await _controller.CreateAsync(request);

            var createdResult = Assert.IsType<CreatedAtRouteResult>(result);
            Assert.Equal("GetStudentTypeById", createdResult.RouteName);

            var returnType = Assert.IsType<StudentTypeResponse>(createdResult.Value);
            Assert.Equal(1, returnType.Id);
        }

        [Fact]
        public async Task UpdateStudentTypeAsync_ShouldReturnNoContent()
        {
            var request = StudentTypeMockData.UpdateRequest();

            _mockFacade.Setup(f => f.Update.ExecuteAsync(1, request))
                       .Returns(Task.CompletedTask);

            var result = await _controller.UpdateAsync(1, request);
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteStudentTypeAsync_ShouldReturnNoContent()
        {
            _mockFacade.Setup(f => f.Delete.ExecuteAsync(1))
                       .Returns(Task.CompletedTask);

            var result = await _controller.DeleteAsync(1);
            Assert.IsType<NoContentResult>(result);
        }
    }
}
