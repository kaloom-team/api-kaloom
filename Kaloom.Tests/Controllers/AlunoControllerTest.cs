using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Kaloom.API.Controllers;
using Kaloom.API.UseCases.Students;
using Kaloom.API.UseCases.Students.GetAll;
using Kaloom.API.UseCases.Students.GetById;
using Kaloom.Tests.MockData;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Kaloom.Tests.Controllers
{
    public class AlunoControllerTest
    {
        [Fact]
        public async Task GetAllStudentsAsync_ShouldReturn200Status()
        {
            var getAllMock = new Mock<IGetAllStudentsUseCase>();
            getAllMock.Setup(_ => _.ExecuteAsync()).ReturnsAsync(AlunoMockData.GetAll());

            var studentsUseCases = new Mock<IStudentsUseCases>();
            studentsUseCases.SetupGet(s => s.GetAll).Returns(getAllMock.Object);

            var sut = new AlunoController(studentsUseCases.Object);

            var result = (OkObjectResult) await sut.GetAllAsync();

            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);

        }

        [Theory]
        [InlineData(1)]
        public async Task GetStudentById_ShouldReturns200Status(int id)
        {
            var getByIdMock = new Mock<IGetStudentByIdUseCase>();
            getByIdMock.Setup(_ => _.ExecuteAsync(id)).ReturnsAsync(AlunoMockData.GetById(id));

            var studentsUseCases = new Mock<IStudentsUseCases>();
            studentsUseCases.SetupGet(s => s.GetById).Returns(getByIdMock.Object);

            var sut = new AlunoController(studentsUseCases.Object);

            var result = (OkObjectResult) await sut.GetByIdAsync(id);
            var name = (OkObjectResult)await sut.GetByIdAsync(id);

            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
        }
    }
}
