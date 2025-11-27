namespace Kaloom.Students.Application.UseCases.StudentsTypes.Delete
{
    public interface IDeleteStudentTypeUseCase
    {
        public Task ExecuteAsync(int id);
    }
}