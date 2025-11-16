using Kaloom.API.Controllers;
using Kaloom.API.Facades;
using Kaloom.API.UseCases.Students;
using Kaloom.API.UseCases.Students.GetAll;
using Kaloom.API.UseCases.Students.GetById;
using Kaloom.Communication.DTOs.Requests;
using Kaloom.Communication.DTOs.Responses;
using Kaloom.Tests.MockData;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Kaloom.Tests.Controllers
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

        [Fact]
        public async Task RegisterAsync_ReturnsCreatedResult_WithStudentResponse()
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
        public async Task UpdateAsync_ReturnsNoContent()
        {
            var request = AlunoMockData.UpdateRequest("First name", "Last name");

            _mockFacade.Setup(f => f.Update.ExecuteAsync(1, request))
                       .Returns(Task.CompletedTask);

            var result = await _controller.UpdateAsync(1, request);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteAsync_ReturnsNoContent()
        {
            _mockFacade.Setup(f => f.Delete.ExecuteAsync(1))
                       .Returns(Task.CompletedTask);

            var result = await _controller.DeleteAsync(1);

            Assert.IsType<NoContentResult>(result);
        }
    }
}