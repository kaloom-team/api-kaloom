using AutoMapper;
using Kaloom.Users.Communication.DTOs.Responses;
using Kaloom.Users.Domain.Repositories.Abstractions;

namespace Kaloom.Users.Application.UseCases.Users.GetAll
{
    public class GetAllUsersUseCase : IGetAllUsersUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetAllUsersUseCase(IUserRepository userRepository, IMapper mapper)
        {
            this._userRepository = userRepository;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<UserResponse>> ExecuteAsync()
        {
            var usuarios = await this._userRepository.GetAllAsync();

            var response = this._mapper.Map<IEnumerable<UserResponse>>(usuarios);

            return response;
        }
    }
}