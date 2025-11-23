namespace Kaloom.Application.UseCases.Fatecs.Delete
{
    public interface IDeleteFatecUseCase
    {
        public Task ExecuteAsync(int id);
    }
}