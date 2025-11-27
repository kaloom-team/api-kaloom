using Kaloom.Users.Communication.DTOs.Requests;

namespace Kaloom.Users.Application.UseCases.Users.Update
{
    public interface IUpdateUserUseCase
    {
        public Task ExecuteAsync(int id, UserRequest request);
    }
}