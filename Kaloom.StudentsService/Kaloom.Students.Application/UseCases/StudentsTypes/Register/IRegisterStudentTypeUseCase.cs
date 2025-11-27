using Kaloom.Students.Communication.DTOs.Requests;
using Kaloom.Students.Communication.DTOs.Responses;

namespace Kaloom.Students.Application.UseCases.StudentsTypes.Register
{
    public interface IRegisterStudentTypeUseCase
    {
        Task<StudentTypeResponse> ExecuteAsync(StudentTypeRequest request);
    }
}