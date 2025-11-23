using Kaloom.Communication.DTOs.Requests;
using Kaloom.Communication.DTOs.Responses;

namespace Kaloom.Application.UseCases.Users.Register
{
    public interface IRegisterUserUseCase
    {
        public Task<UserResponse> ExecuteAsync(UserRequest request);
    }
}