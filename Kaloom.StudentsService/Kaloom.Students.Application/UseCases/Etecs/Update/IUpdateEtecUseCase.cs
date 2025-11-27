using Kaloom.Students.Communication.DTOs.Requests;

namespace Kaloom.Students.Application.UseCases.Etecs.Update
{
    public interface IUpdateEtecUseCase
    {
        public Task ExecuteAsync(int id, EtecRequest request);
    }
}
