using Kaloom.Users.Communication.DTOs.Responses;

namespace Kaloom.Users.Application.UseCases.Users.GetById
{
    public interface IGetUserByIdUseCase
    {
        public Task<UserResponse> ExecuteAsync(int id);
    }
}