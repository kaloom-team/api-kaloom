using Kaloom.Communication.DTOs.Responses;

namespace Kaloom.Application.UseCases.StudentsTypes.GetById
{
    public interface IGetStudentTypeByIdUseCase
    {
        public Task<StudentTypeResponse> ExecuteAsync(int id);
    }
}