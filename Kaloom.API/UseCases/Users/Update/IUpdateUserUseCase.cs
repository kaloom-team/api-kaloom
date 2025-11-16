using Kaloom.Communication.DTOs.Requests;

namespace Kaloom.API.UseCases.Users.Update
{
    public interface IUpdateUserUseCase
    {
        public Task ExecuteAsync(int id, UserRequest request);
    }
}