using Kaloom.API.Context;
using Kaloom.Exceptions.ExceptionsBase;

namespace Kaloom.API.UseCases.StudentsTypes.Delete
{
    public class DeleteStudentTypeUseCase : IDeleteStudentTypeUseCase
    {
        private readonly KaloomContext _context;

        public DeleteStudentTypeUseCase(KaloomContext context)
        {
            this._context = context;
        }

        public async Task ExecuteAsync(int id)
        {
            var tipoAluno = await this._context.TipoAlunos.FindAsync(id)
                ?? throw new NotFoundException($"Tipo de aluno de ID {id} não encontrado.");

            this._context.Remove(tipoAluno);
            await this._context.SaveChangesAsync();
        }
    }
}