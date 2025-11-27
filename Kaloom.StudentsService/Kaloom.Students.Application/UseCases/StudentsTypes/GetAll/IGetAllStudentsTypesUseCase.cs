using Kaloom.Students.Communication.DTOs.Responses;

namespace Kaloom.Students.Application.UseCases.StudentsTypes.GetAll
{
    public interface IGetAllStudentsTypesUseCase
    {
        public Task<IReadOnlyList<StudentTypeResponse>> ExecuteAsync();
    }
}