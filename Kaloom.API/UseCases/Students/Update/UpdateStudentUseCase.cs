using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kaloom.API.Context;
using Kaloom.API.Factories;
using Kaloom.Communication.DTOs.Requests;
using Kaloom.API.UseCases.Students.Utils;
using Kaloom.Exceptions.ExceptionsBase;

namespace Kaloom.API.UseCases.Students.Update
{
    public class UpdateStudentUseCase : IUpdateStudentUseCase
    {
        private readonly KaloomContext _context;
        private readonly IStudentFactory _studentFactory;
        public UpdateStudentUseCase(KaloomContext context, IStudentFactory studentFactory)
        {
            this._context = context;
            this._studentFactory = studentFactory;
        }
        public async Task ExecuteAsync(int id, StudentRequest request)
        {
            StudentValidate.Validate(request);

            var aluno = await this._context.Alunos.FindAsync(id) ?? throw new NotFoundException($"Aluno com ID {id} não encontrado.");

            aluno.Nome = request.Nome;
            aluno.Sobrenome = request.Sobrenome;
            aluno.NomeUsuario = request.NomeUsuario;
            aluno.DataNascimento = request.DataNascimento;

            this._context.Alunos.Update(aluno);
            await this._context.SaveChangesAsync();
        }
    }
}