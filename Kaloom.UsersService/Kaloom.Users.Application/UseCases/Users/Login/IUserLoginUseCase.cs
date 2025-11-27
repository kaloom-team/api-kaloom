using Kaloom.Users.Communication.DTOs.Requests;
using Kaloom.Users.Communication.DTOs.Responses;

namespace Kaloom.Users.Application.UseCases.Users.Login
{
    public interface IUserLoginUseCase
    {
        public Task<UserLoginResponse> ExecuteAsync(UserRequest request);
    }
}