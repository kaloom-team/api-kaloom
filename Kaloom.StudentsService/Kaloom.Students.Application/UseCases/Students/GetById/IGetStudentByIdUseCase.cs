using Kaloom.SharedContracts.DTOs;

namespace Kaloom.Students.Application.UseCases.Students.GetById
{
    public interface IGetStudentByIdUseCase
    {
        public Task<StudentResponse> ExecuteAsync(int id);
    }
}