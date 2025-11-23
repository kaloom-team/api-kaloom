using AutoMapper;
using Kaloom.Communication.DTOs.Requests;
using Kaloom.Communication.DTOs.Responses;
using Kaloom.Domain.Models;
using Kaloom.Domain.Repositories.Abstractions;
using Kaloom.Exceptions.ExceptionsBase;
using static Kaloom.Application.UseCases.Users.Utils.UserValidate;

namespace Kaloom.Application.UseCases.Users.Register
{
    public class RegisterUserUseCase : IRegisterUserUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public RegisterUserUseCase(IUserRepository userRepository, IMapper mapper)
        {
            this._userRepository = userRepository;
            this._mapper = mapper;
        }

        public async Task<UserResponse> ExecuteAsync(UserRequest request)
        {
            Validate(request);

            var users = await this._userRepository.GetAllAsync();

            if (users.Any(u => u.Email == request.Email))
            {
                throw new ErrorOnValidationException("Email já cadastrado.");
            }

            var usuario = _mapper.Map<Usuario>(request);

            await _userRepository.AddAsync(usuario);

            return _mapper.Map<UserResponse>(usuario);
        }
    }
}