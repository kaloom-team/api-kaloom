using Kaloom.Communication.DTOs.Responses;

namespace Kaloom.API.UseCases.Users.GetById
{
    public interface IGetUserByIdUseCase
    {
        public Task<UserResponse> ExecuteAsync(int id);
    }
}