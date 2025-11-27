using Kaloom.Students.Communication.DTOs.Responses;

namespace Kaloom.Students.Application.UseCases.StudentsTypes.GetById
{
    public interface IGetStudentTypeByIdUseCase
    {
        public Task<StudentTypeResponse> ExecuteAsync(int id);
    }
}