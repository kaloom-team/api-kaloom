using Kaloom.Students.Communication.DTOs.Responses;

namespace Kaloom.Students.Application.UseCases.Fatecs.GetById
{
    public interface IGetFatecByIdUseCase
    {
        public Task<FatecResponse> ExecuteAsync(int id);
    }
}