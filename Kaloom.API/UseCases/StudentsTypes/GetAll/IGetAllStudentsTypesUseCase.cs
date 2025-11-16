using Kaloom.Communication.DTOs.Responses;

namespace Kaloom.API.UseCases.StudentsTypes.GetAll
{
    public interface IGetAllStudentsTypesUseCase
    {
        public Task<IReadOnlyList<StudentTypeResponse>> ExecuteAsync();
    }
}