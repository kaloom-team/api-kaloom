using Kaloom.Communication.DTOs.Requests;

namespace Kaloom.API.UseCases.Fatecs.Update
{
    public interface IUpdateFatecUseCase
    {
        public Task ExecuteAsync(int id, FatecRequest request);
    }
}