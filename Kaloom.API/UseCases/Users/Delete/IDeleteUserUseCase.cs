using Kaloom.Communication.DTOs.Requests;

namespace Kaloom.API.UseCases.Users.Delete
{
    public interface IDeleteUserUseCase
    {
        public Task ExecuteAsync(int id);
    }
}
