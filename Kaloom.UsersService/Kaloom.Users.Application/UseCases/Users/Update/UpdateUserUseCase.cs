using Kaloom.Users.Communication.DTOs.Requests;
using Kaloom.Users.Domain.Repositories.Abstractions;
using Kaloom.Users.Exceptions.ExceptionsBase;
using static Kaloom.Users.Application.UseCases.Users.Utils.UserValidate;

namespace Kaloom.Users.Application.UseCases.Users.Update
{
    public class UpdateUserUseCase : IUpdateUserUseCase
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserUseCase(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }
        public async Task ExecuteAsync(int id, UserRequest request)
        {
            Validate(request);

            var users = await this._userRepository.GetAllAsync();

            if (users.Any(u => u.Email == request.Email && u.Id != id))
            {
                throw new ErrorOnValidationException("Email já cadastrado.");
            }

            if (users.Any(e => e.NomeUsuario.ToLower() == request.NomeUsuario.ToLower() && e.Id != id))
            {
                throw new ErrorOnValidationException("Nome de usuário já em uso.");
            }

            var usuario = await this._userRepository.GetByIdAsync(id)
                ?? throw new NotFoundException($"Usuario com ID {id} não encontrado.");


            usuario.Email = request.Email;
            usuario.Senha = request.Senha;

            await this._userRepository.UpdateAsync(usuario);
        }
    }
}