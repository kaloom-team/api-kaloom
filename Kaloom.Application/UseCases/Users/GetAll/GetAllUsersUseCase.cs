using AutoMapper;
using Kaloom.Communication.DTOs.Responses;
using Kaloom.Domain.Repositories.Abstractions;

namespace Kaloom.Application.UseCases.Users.GetAll
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