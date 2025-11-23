using Kaloom.Communication.DTOs.Responses;

namespace Kaloom.Application.UseCases.Students.GetById
{
    public interface IGetStudentByIdUseCase
    {
        public Task<StudentResponse> ExecuteAsync(int id);
    }
}