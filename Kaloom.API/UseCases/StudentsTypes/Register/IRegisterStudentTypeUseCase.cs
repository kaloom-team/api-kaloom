using Kaloom.Communication.DTOs.Requests;
using Kaloom.Communication.DTOs.Responses;

namespace Kaloom.API.UseCases.StudentsTypes.Register
{
    public interface IRegisterStudentTypeUseCase
    {
        Task<StudentTypeResponse> ExecuteAsync(StudentTypeRequest request);
    }
}