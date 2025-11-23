using Kaloom.Communication.DTOs.Requests;
using Kaloom.Communication.DTOs.Responses;

namespace Kaloom.Application.UseCases.Etecs.Register
{
    public interface IRegisterEtecUseCase
    {
        public Task<EtecResponse> ExecuteAsync(EtecRequest etec);
    }
}
