using Kaloom.Communication.DTOs.Requests;

namespace Kaloom.Application.UseCases.StudentsTypes.Update
{
    public interface IUpdateStudentTypeUseCase
    {
        public Task ExecuteAsync(int id, StudentTypeRequest request);
    }
}