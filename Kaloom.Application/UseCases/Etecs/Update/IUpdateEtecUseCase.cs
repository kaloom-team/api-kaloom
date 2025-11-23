using Kaloom.Communication.DTOs.Requests;

namespace Kaloom.Application.UseCases.Etecs.Update
{
    public interface IUpdateEtecUseCase
    {
        public Task ExecuteAsync(int id, EtecRequest request);
    }
}
