using Kaloom.Students.Communication.DTOs.Requests;
using Kaloom.Students.Communication.DTOs.Responses;

namespace Kaloom.Students.Application.UseCases.Students.Register
{
    public interface IRegisterStudentUseCase
    {
        public Task<StudentShortResponse> ExecuteAsync(StudentRequest request);
    }
}