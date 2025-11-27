using Kaloom.Students.Communication.DTOs.Requests;

namespace Kaloom.Students.Application.UseCases.Fatecs.Update
{
    public interface IUpdateFatecUseCase
    {
        public Task ExecuteAsync(int id, FatecRequest request);
    }
}