using Kaloom.Users.Communication.DTOs.Requests;
using Kaloom.Users.Communication.DTOs.Responses;

namespace Kaloom.Users.Application.UseCases.Users.Register
{
    public interface IRegisterUserUseCase
    {
        public Task<UserResponse> ExecuteAsync(UserRequest request);
    }
}