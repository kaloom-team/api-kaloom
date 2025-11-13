using Kaloom.API.Context;
using Kaloom.API.UseCases.Students.Utils;
using Kaloom.Communication.DTOs.Requests;
using Kaloom.Exceptions.ExceptionsBase;
using Microsoft.EntityFrameworkCore;
using static Kaloom.API.UseCases.Users.Utils.UserValidate;

namespace Kaloom.API.UseCases.Users.Update
{
    public class UpdateUserUseCase : IUpdateUserUseCase
    {
        private readonly KaloomContext _context;

        public UpdateUserUseCase(KaloomContext context)
        {
            this._context = context;
        }
        public async Task ExecuteAsync(int id, UserRequest request)
        {
            Validate(request);

            if (await this._context.Usuarios
                .AsNoTracking()
                .AnyAsync(u => u.Email == request.Email && u.Id != id))
            {
                throw new ErrorOnValidationException("Email já cadastrado.");
            }

            var usuario = await this._context.Usuarios.FindAsync(id) ?? throw new NotFoundException($"Usuario com ID {id} não encontrado.");


            usuario.Email = request.Email;
            usuario.Senha = request.Senha;

            this._context.Update(usuario);
            await this._context.SaveChangesAsync();
        }
    }
}
