using Kaloom.Communication.DTOs.Responses;

namespace Kaloom.Application.UseCases.StudentsTypes.GetAll
{
    public interface IGetAllStudentsTypesUseCase
    {
        public Task<IReadOnlyList<StudentTypeResponse>> ExecuteAsync();
    }
}