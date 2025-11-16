using Kaloom.Communication.DTOs.Responses;

namespace Kaloom.API.UseCases.Students.GetAll
{
    public interface IGetAllStudentsUseCase
    {
        public Task<IEnumerable<StudentResponse>> ExecuteAsync();
    }
}