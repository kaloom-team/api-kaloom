using Kaloom.Students.Communication.DTOs.Requests;

namespace Kaloom.Students.Application.UseCases.StudentsTypes.Update
{
    public interface IUpdateStudentTypeUseCase
    {
        public Task ExecuteAsync(int id, StudentTypeRequest request);
    }
}