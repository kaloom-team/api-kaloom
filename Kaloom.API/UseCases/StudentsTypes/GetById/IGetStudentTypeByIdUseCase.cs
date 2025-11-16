using Kaloom.Communication.DTOs.Responses;

namespace Kaloom.API.UseCases.StudentsTypes.GetById
{
    public interface IGetStudentTypeByIdUseCase
    {
        public Task<StudentTypeResponse> ExecuteAsync(int id);
    }
}