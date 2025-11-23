using Kaloom.Communication.DTOs.Requests;
using Kaloom.Communication.DTOs.Responses;

namespace Kaloom.Application.UseCases.Users.Login
{
    public interface IUserLoginUseCase
    {
        public Task<UserLoginResponse> ExecuteAsync(UserRequest request);
    }
}