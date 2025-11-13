using Kaloom.API.Context;
using Kaloom.Exceptions.ExceptionsBase;
using Microsoft.EntityFrameworkCore;

namespace Kaloom.API.UseCases.Students.Delete
{
    public class DeleteStudentUseCase : IDeleteStudentUseCase
    {
        private readonly KaloomContext _context;
        public DeleteStudentUseCase(KaloomContext context)
        {
            this._context = context;
        }

        public async Task ExecuteAsync(int id)
        {
            var aluno = await this._context.Alunos
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(a => a.Id == id)
                ?? throw new NotFoundException($"Aluno com ID {id} não encontrado.");

            this._context.Alunos.Remove(aluno);
            await this._context.SaveChangesAsync();
        }
    }
}