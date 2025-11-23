using Kaloom.Domain.Repositories.Abstractions;
using Kaloom.Exceptions.ExceptionsBase;

namespace Kaloom.Application.UseCases.Users.Delete
{
    public class DeleteUserUseCase : IDeleteUserUseCase
    {
        private readonly IUserRepository _userRepository;
        public DeleteUserUseCase(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public async Task ExecuteAsync(int id)
        {
            var usuario = await this._userRepository.GetByIdAsync(id)
                ?? throw new NotFoundException($"Usuario de ID {id} não encontrado.");

            await this._userRepository.DeleteAsync(usuario);
        }
    }
}