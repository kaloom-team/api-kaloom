using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kaloom.API.Models;
using Microsoft.EntityFrameworkCore;
using Kaloom.API.Context;

namespace Kaloom.API.UseCases.Students.GetById
{
    public class GetStudentByIdUseCase : IGetStudentByIdUseCase
    {
        private readonly KaloomContext _context;

        public GetStudentByIdUseCase(KaloomContext context)
        {
            _context = context;
        }

        public async Task<Aluno> ExecuteAsync(int id)
        {
            var aluno = await _context.Alunos
                .Include(u => u.Usuario)
                .Include(u => u.TipoAluno)
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id);

            return aluno;
        }
    }
}