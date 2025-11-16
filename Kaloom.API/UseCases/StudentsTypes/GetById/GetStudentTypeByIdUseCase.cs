using Kaloom.API.Context;
using Kaloom.API.Factories;
using Kaloom.Communication.DTOs.Responses;
using Kaloom.Exceptions.ExceptionsBase;
using Microsoft.EntityFrameworkCore;

namespace Kaloom.API.UseCases.StudentsTypes.GetById
{
    public class GetStudentTypeByIdUseCase : IGetStudentTypeByIdUseCase
    {
        private readonly KaloomContext _context;
        private readonly IStudentTypeResponseFactory _studentTypeFactory;

        public GetStudentTypeByIdUseCase(KaloomContext context, IStudentTypeResponseFactory studentTypeFactory)
        {
            this._context = context;
            this._studentTypeFactory = studentTypeFactory;
        }

        public async Task<StudentTypeResponse> ExecuteAsync(int id)
        {
            var tipoAluno = await this._context.TipoAlunos
               .AsNoTracking()
               .FirstOrDefaultAsync(e => e.Id == id)
               ?? throw new NotFoundException($"Nenhum tipo de aluno encontrado com o ID {id}.");

            return this._studentTypeFactory.Create(tipoAluno);
        }
    }
}