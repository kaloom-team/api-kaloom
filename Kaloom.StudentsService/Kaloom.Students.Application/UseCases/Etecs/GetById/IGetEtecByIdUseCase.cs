using Kaloom.Students.Communication.DTOs.Responses;

namespace Kaloom.Students.Application.UseCases.Etecs.GetById
{
    public interface IGetEtecByIdUseCase
    {
        public Task<EtecResponse> ExecuteAsync(int id);
    }
}
