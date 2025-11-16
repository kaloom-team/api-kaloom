using Kaloom.Communication.DTOs.Responses;

namespace Kaloom.API.UseCases.Users.GetAll
{
    public interface IGetAllUsersUseCase
    {
        public Task<IEnumerable<UserResponse>> ExecuteAsync();
    }
}