using Kaloom.Communication.DTOs.Responses;

namespace Kaloom.Application.UseCases.Users.GetAll
{
    public interface IGetAllUsersUseCase
    {
        public Task<IEnumerable<UserResponse>> ExecuteAsync();
    }
}