using AutoMapper;
using Kaloom.Users.Communication.DTOs.Requests;
using Kaloom.Users.Communication.DTOs.Responses;
using Kaloom.Users.Domain.Models;
using Kaloom.Users.Domain.Repositories.Abstractions;
using Kaloom.Users.Exceptions.ExceptionsBase;
using static Kaloom.Users.Application.UseCases.Users.Utils.UserValidate;

namespace Kaloom.Users.Application.UseCases.Users.Register
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

            if (users.Any(e => e.NomeUsuario.ToLower() == request.NomeUsuario.ToLower() && e.Id != request.Id))
            {
                throw new ErrorOnValidationException("Nome de usuário já em uso.");
            }

            var usuario = _mapper.Map<Usuario>(request);

            await _userRepository.AddAsync(usuario);

            return _mapper.Map<UserResponse>(usuario);
        }
    }
}