using Kaloom.Communication.DTOs.Responses;

namespace Kaloom.Application.UseCases.Users.GetById
{
    public interface IGetUserByIdUseCase
    {
        public Task<UserResponse> ExecuteAsync(int id);
    }
}