using Kaloom.API.Context;
using Kaloom.Communication.DTOs.Requests;
using Kaloom.Exceptions.ExceptionsBase;
using Microsoft.EntityFrameworkCore;
using static Kaloom.API.UseCases.StudentsTypes.Utils.StudentTypeValidate;

namespace Kaloom.API.UseCases.StudentsTypes.Update
{
    public class UpdateStudentTypeUseCase : IUpdateStudentTypeUseCase
    {
        private readonly KaloomContext _context;
        public UpdateStudentTypeUseCase(KaloomContext context)
        {
            this._context = context;
        }
        public async Task ExecuteAsync(int id, StudentTypeRequest request)
        {
            Validate(request);

            var tipoAluno = await this._context.TipoAlunos.FindAsync(id)
                ?? throw new NotFoundException($"Tipo de aluno com ID {id} não encontrado.");

            if (await this._context.TipoAlunos
                .AsNoTracking()
                .AnyAsync(t =>
                    t.Etec == request.Etec &&
                    t.Etec == request.Etec &&
                    t.Fatec == request.Fatec &&
                    t.StatusEtec == request.StatusEtec &&
                    t.StatusFatec == request.StatusFatec &&
                    t.Id != id
                )
            )
            {
                throw new ErrorOnValidationException("Tipo de aluno já cadastrado.");
            }


            tipoAluno.Etec = request.Etec;
            tipoAluno.Fatec = request.Fatec;
            tipoAluno.StatusEtec = request.StatusEtec;
            tipoAluno.StatusFatec = request.StatusFatec;
            tipoAluno.Description = request.Description;


            this._context.Update(tipoAluno);
            await _context.SaveChangesAsync();
        }
    }
}