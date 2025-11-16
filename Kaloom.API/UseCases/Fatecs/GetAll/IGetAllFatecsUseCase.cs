using Kaloom.Communication.DTOs.Responses;

namespace Kaloom.API.UseCases.Fatecs.GetAll
{
    public interface IGetAllFatecsUseCase
    {
        public Task<IEnumerable<FatecResponse>> ExecuteAsync();
    }
}