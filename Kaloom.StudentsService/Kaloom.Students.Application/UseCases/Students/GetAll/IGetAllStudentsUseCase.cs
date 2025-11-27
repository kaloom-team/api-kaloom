using Kaloom.SharedContracts.DTOs;

namespace Kaloom.Students.Application.UseCases.Students.GetAll
{
    public interface IGetAllStudentsUseCase
    {
        public Task<IEnumerable<StudentResponse>> ExecuteAsync();
    }
}