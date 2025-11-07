using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kaloom.API.Models;
using Microsoft.EntityFrameworkCore;
using Kaloom.API.Context;
using Kaloom.Exceptions.ExceptionsBase;
using Kaloom.API.Factories;
using Kaloom.Communication.DTOs.Responses;

namespace Kaloom.API.UseCases.Students.GetById
{
    public class GetStudentByIdUseCase : IGetStudentByIdUseCase
    {
        private readonly KaloomContext _context;
        private readonly IStudentShortFactory _studentShortFactory;

        public GetStudentByIdUseCase(KaloomContext context, IStudentShortFactory studentShortFactory)
        {
            _context = context;
            _studentShortFactory = studentShortFactory;
        }

        public async Task<StudentShortResponse> ExecuteAsync(int id)
        {
            var aluno = await _context.Alunos
                .Include(u => u.Usuario)
                .Include(u => u.TipoAluno)
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id) ?? throw new NotFoundException("Aluno não encontrado.");

            return _studentShortFactory.Create(aluno);
        }
    }
}