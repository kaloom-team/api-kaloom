using Kaloom.Communication.DTOs.Responses;

namespace Kaloom.Application.UseCases.Fatecs.GetById
{
    public interface IGetFatecByIdUseCase
    {
        public Task<FatecResponse> ExecuteAsync(int id);
    }
}