namespace Kaloom.API.UseCases.StudentsTypes.Delete
{
    public interface IDeleteStudentTypeUseCase
    {
        public Task ExecuteAsync(int id);
    }
}