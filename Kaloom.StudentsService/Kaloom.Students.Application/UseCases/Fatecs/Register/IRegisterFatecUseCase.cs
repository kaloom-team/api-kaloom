using Kaloom.Students.Communication.DTOs.Requests;
using Kaloom.Students.Communication.DTOs.Responses;

namespace Kaloom.Students.Application.UseCases.Fatecs.Register
{
    public interface IRegisterFatecUseCase
    {
        public Task<FatecResponse> ExecuteAsync(FatecRequest request);
    }
}