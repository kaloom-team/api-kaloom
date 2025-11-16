using Kaloom.Communication.DTOs.Requests;

namespace Kaloom.API.UseCases.Students.Update
{
    public interface IUpdateStudentUseCase
    {
        public Task ExecuteAsync(int id, StudentRequest request);
    }
}