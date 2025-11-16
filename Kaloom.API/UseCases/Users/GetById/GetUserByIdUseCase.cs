using Kaloom.API.Context;
using Kaloom.Communication.DTOs.Responses;
using Kaloom.Exceptions.ExceptionsBase;
using Microsoft.EntityFrameworkCore;

namespace Kaloom.API.UseCases.Users.GetById
{
    public class GetUserByIdUseCase : IGetUserByIdUseCase
    {
        private readonly KaloomContext _context;
        public GetUserByIdUseCase(KaloomContext context)
        {
            this._context = context;
        }

        public async Task<UserResponse> ExecuteAsync(int id)
        {
            var usuario = await this._context.Usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id) ?? throw new NotFoundException($"Usuário de ID {id} não encontrado.");

            return new UserResponse
            (
                usuario.Id,
                usuario.Email
            );
        }
    }
}