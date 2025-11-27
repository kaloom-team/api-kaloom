using Kaloom.Users.Communication.DTOs.Responses;
using Kaloom.Users.Domain.Repositories.Abstractions;
using Kaloom.Users.Exceptions.ExceptionsBase;

namespace Kaloom.Users.Application.UseCases.Users.GetById
{
    public class GetUserByIdUseCase : IGetUserByIdUseCase
    {
        private readonly IUserRepository _userRepository;
        public GetUserByIdUseCase(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public async Task<UserResponse> ExecuteAsync(int id)
        {
            var usuario = await this._userRepository.GetByIdAsync(id)
                ?? throw new NotFoundException($"Usuário de ID {id} não encontrado.");

            return new UserResponse
            (
                usuario.Id,
                usuario.Email,
                usuario.NomeUsuario,
                usuario.FotoPerfil,
                usuario.FotoCapa,
                usuario.Biografia
            );
        }
    }
}