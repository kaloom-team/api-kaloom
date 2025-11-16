using Kaloom.Communication.DTOs.Responses;

namespace Kaloom.API.UseCases.Etecs.GetAll
{
    public interface IGetAllEtecsUseCase
    {
        public Task<IEnumerable<EtecResponse>> ExecuteAsync();
    }
}
