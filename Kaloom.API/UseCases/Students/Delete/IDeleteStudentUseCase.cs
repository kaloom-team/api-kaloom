namespace Kaloom.API.UseCases.Students.Delete
{
    public interface IDeleteStudentUseCase
    {
        public Task ExecuteAsync(int id);
    }
}