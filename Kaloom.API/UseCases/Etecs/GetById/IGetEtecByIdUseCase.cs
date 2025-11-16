using Kaloom.Communication.DTOs.Responses;

namespace Kaloom.API.UseCases.Etecs.GetById
{
    public interface IGetEtecByIdUseCase
    {
        public Task<EtecResponse> ExecuteAsync(int id);
    }
}
