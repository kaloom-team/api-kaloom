using Kaloom.SharedContracts.DTOs;
using Kaloom.Students.API.Controllers;
using Kaloom.Students.Application.Facades;
using Kaloom.Students.Application.UseCases.Students.GetAll;
using Kaloom.Students.Application.UseCases.Students.GetById;
using Kaloom.Students.Communication.DTOs.Responses;
using Kaloom.Students.Exceptions.ExceptionsBase;
using Kaloom.Students.Tests.MockData;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;

namespace Kaloom.Students.Tests.Controllers
{
    public class AlunoControllerTests
    {
        private readonly Mock<IStudentFacade> _mockFacade;
        private readonly AlunoController _controller;

        public AlunoControllerTests()
        {
            this._mockFacade = new Mock<IStudentFacade>();
            this._controller = new AlunoController(_mockFacade.Object);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsOkResult_WithListOfStudents()
        {
            _mockFacade.Setup(f => f.GetAll.ExecuteAsync())
                .ReturnsAsync(AlunoMockData.GetAllShortList());
            
            var result = await _controller.GetAllAsync();

            var resultOk = Assert.IsType<OkObjectResult>(result);
            var returnStudents = Assert.IsAssignableFrom<IEnumerable<StudentResponse>>(resultOk.Value);
            Assert.Equal(2, returnStudents.Count());
        }


        [Fact]
        public async Task GetAllStudentsAsync_ShouldReturn200Status()
        {
            var getAllMock = new Mock<IGetAllStudentsUseCase>();
            getAllMock.Setup(_ => _.ExecuteAsync())
                .ReturnsAsync(AlunoMockData.GetAll());

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
        public async Task GetStudentByIdAsync_ShouldReturns200Status(int id)
        {
            var getByIdMock = new Mock<IGetStudentByIdUseCase>();
            getByIdMock.Setup(_ => _.ExecuteAsync(id))
                .ReturnsAsync(AlunoMockData.GetById(id));

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
        public async Task GetStudentByIdAsync_ShouldReturns404Status(int id)
        {
            var getByIdMock = new Mock<IGetStudentByIdUseCase>();

            getByIdMock.Setup(_ => _.ExecuteAsync(id))
                .ThrowsAsync(new NotFoundException($"Aluno com ID {id} não encontrado."));

            _mockFacade.SetupGet(f => f.GetById)
                .Returns(getByIdMock.Object);

            var exception = await Assert.ThrowsAsync<NotFoundException>(() => _controller.GetByIdAsync(id));

            Assert.Equal($"Aluno com ID {id} não encontrado.", exception.Message);
        }

        [Fact]
        public async Task RegisterStudentAsync_ReturnsCreatedResult_WithStudentResponse()
        {
            var request = AlunoMockData.RegisterRequest();
            _mockFacade.Setup(f => f.Register.ExecuteAsync(request))
                .ReturnsAsync(AlunoMockData.RegisterResponse());

            var result = await _controller.CreateAsync(request);

            var createdResult = Assert.IsType<CreatedAtRouteResult>(result);
            Assert.Equal("GetStudentById", createdResult.RouteName);
            var returnStudent = Assert.IsType<StudentShortResponse>(createdResult.Value);
            Assert.Equal(1, returnStudent.Id);
        }

        [Fact]
        public async Task UpdateStudentAsync_ReturnsNoContent()
        {
            var request = AlunoMockData.UpdateRequest("First name", "Last name");

            _mockFacade.Setup(f => f.Update.ExecuteAsync(1, request))
                       .Returns(Task.CompletedTask);

            var result = await _controller.UpdateAsync(1, request);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteStudentAsync_ReturnsNoContent()
        {
            _mockFacade.Setup(f => f.Delete.ExecuteAsync(1))
                       .Returns(Task.CompletedTask);

            var result = await _controller.DeleteAsync(1);

            Assert.IsType<NoContentResult>(result);
        }
    }
}