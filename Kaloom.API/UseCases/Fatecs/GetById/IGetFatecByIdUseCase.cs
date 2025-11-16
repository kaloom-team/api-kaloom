using Kaloom.Communication.DTOs.Responses;

namespace Kaloom.API.UseCases.Fatecs.GetById
{
    public interface IGetFatecByIdUseCase
    {
        public Task<FatecResponse> ExecuteAsync(int id);
    }
}