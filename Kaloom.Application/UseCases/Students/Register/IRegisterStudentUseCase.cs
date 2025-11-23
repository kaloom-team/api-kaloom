using Kaloom.Communication.DTOs.Requests;
using Kaloom.Communication.DTOs.Responses;

namespace Kaloom.Application.UseCases.Students.Register
{
    public interface IRegisterStudentUseCase
    {
        public Task<StudentShortResponse> ExecuteAsync(StudentRequest request);
    }
}