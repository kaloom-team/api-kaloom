using Kaloom.Students.Communication.DTOs.Requests;
using Kaloom.Students.Communication.DTOs.Responses;

namespace Kaloom.Students.Application.UseCases.Etecs.Register
{
    public interface IRegisterEtecUseCase
    {
        public Task<EtecResponse> ExecuteAsync(EtecRequest etec);
    }
}
