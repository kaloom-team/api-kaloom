using Kaloom.API.Context;
using Kaloom.API.UseCases.Students.Utils;
using Kaloom.Communication.DTOs.Requests;
using Kaloom.Exceptions.ExceptionsBase;

namespace Kaloom.API.UseCases.Students.Update
{
    public class UpdateStudentUseCase : IUpdateStudentUseCase
    {
        private readonly KaloomContext _context;
        public UpdateStudentUseCase(KaloomContext context)
        {
            this._context = context;
        }
        public async Task ExecuteAsync(int id, StudentRequest request)
        {
            var aluno = await this._context.Alunos.FindAsync(id) ?? throw new NotFoundException($"Aluno com ID {id} não encontrado.");

            StudentValidate.Validate(request);

            aluno.Nome = request.Nome;
            aluno.Sobrenome = request.Sobrenome;
            aluno.NomeUsuario = request.NomeUsuario;
            aluno.DataNascimento = request.DataNascimento;

            this._context.Alunos.Update(aluno);
            await this._context.SaveChangesAsync();
        }
    }
}