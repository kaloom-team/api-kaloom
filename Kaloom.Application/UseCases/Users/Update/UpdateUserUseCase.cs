using Kaloom.Communication.DTOs.Requests;
using Kaloom.Domain.Repositories.Abstractions;
using Kaloom.Exceptions.ExceptionsBase;
using static Kaloom.Application.UseCases.Users.Utils.UserValidate;

namespace Kaloom.Application.UseCases.Users.Update
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

            var usuario = await this._userRepository.GetByIdAsync(id)
                ?? throw new NotFoundException($"Usuario com ID {id} não encontrado.");


            usuario.Email = request.Email;
            usuario.Senha = request.Senha;

            await this._userRepository.UpdateAsync(usuario);
        }
    }
}