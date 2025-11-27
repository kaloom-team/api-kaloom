using Kaloom.Students.Communication.DTOs.Responses;

namespace Kaloom.Students.Application.UseCases.Fatecs.GetAll
{
    public interface IGetAllFatecsUseCase
    {
        public Task<IEnumerable<FatecResponse>> ExecuteAsync();
    }
}