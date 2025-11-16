using Kaloom.Communication.DTOs.Requests;
using Kaloom.Communication.DTOs.Responses;

namespace Kaloom.API.UseCases.Fatecs.Register
{
    public interface IRegisterFatecUseCase
    {
        public Task<FatecResponse> ExecuteAsync(FatecRequest request);
    }
}
