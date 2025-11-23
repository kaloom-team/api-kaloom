using Kaloom.Communication.DTOs.Responses;

namespace Kaloom.Application.UseCases.Fatecs.GetAll
{
    public interface IGetAllFatecsUseCase
    {
        public Task<IEnumerable<FatecResponse>> ExecuteAsync();
    }
}