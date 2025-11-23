using Kaloom.Communication.DTOs.Requests;
using Kaloom.Communication.DTOs.Responses;

namespace Kaloom.Application.UseCases.Fatecs.Register
{
    public interface IRegisterFatecUseCase
    {
        public Task<FatecResponse> ExecuteAsync(FatecRequest request);
    }
}