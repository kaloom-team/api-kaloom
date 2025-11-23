using Kaloom.Communication.DTOs.Responses;

namespace Kaloom.Application.UseCases.Students.GetAll
{
    public interface IGetAllStudentsUseCase
    {
        public Task<IEnumerable<StudentResponse>> ExecuteAsync();
    }
}