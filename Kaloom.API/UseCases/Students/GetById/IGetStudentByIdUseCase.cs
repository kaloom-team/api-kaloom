using Kaloom.Communication.DTOs.Responses;

namespace Kaloom.API.UseCases.Students.GetById
{
    public interface IGetStudentByIdUseCase
    {
        public Task<StudentResponse> ExecuteAsync(int id);
    }
}