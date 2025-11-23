namespace Kaloom.Application.UseCases.Users.Delete
{
    public interface IDeleteUserUseCase
    {
        public Task ExecuteAsync(int id);
    }
}