using Kaloom.API.Context;
using Kaloom.Communication.DTOs.Requests;
using Kaloom.Exceptions.ExceptionsBase;

namespace Kaloom.API.UseCases.Users.Delete
{
    public class DeleteUserUseCase : IDeleteUserUseCase
    {
        private readonly KaloomContext _context;
        public DeleteUserUseCase(KaloomContext context)
        {
            this._context = context;
        }

        public async Task ExecuteAsync(int id)
        {
            var usuario = await this._context.Usuarios.FindAsync(id) 
                ?? throw new NotFoundException($"Usuario de ID {id} não encontrado.");

            this._context.Remove(usuario);
            await this._context.SaveChangesAsync();
        }
    }
}
