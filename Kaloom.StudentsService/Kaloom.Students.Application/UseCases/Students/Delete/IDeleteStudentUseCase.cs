namespace Kaloom.Students.Application.UseCases.Students.Delete
{
    public interface IDeleteStudentUseCase
    {
        public Task ExecuteAsync(int id);
    }
}