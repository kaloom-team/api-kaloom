using Kaloom.Communication.DTOs.Responses;

namespace Kaloom.Application.UseCases.Etecs.GetAll
{
    public interface IGetAllEtecsUseCase
    {
        public Task<IEnumerable<EtecResponse>> ExecuteAsync();
    }
}
