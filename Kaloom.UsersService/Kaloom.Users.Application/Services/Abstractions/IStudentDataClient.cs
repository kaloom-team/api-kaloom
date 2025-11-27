using Kaloom.SharedContracts.DTOs;

namespace Kaloom.Users.Application.Services.Abstractions
{
    public interface IStudentDataClient
    {
        Task<StudentResponse?> GetStudentByUserIdAsync(int userId);
    }
}
