using Kaloom.Users.Communication.DTOs.Responses;

namespace Kaloom.Users.Application.UseCases.Users.GetAll
{
    public interface IGetAllUsersUseCase
    {
        public Task<IEnumerable<UserResponse>> ExecuteAsync();
    }
}