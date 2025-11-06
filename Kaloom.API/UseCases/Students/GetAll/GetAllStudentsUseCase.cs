using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kaloom.API.Models;
using Kaloom.API.Context;
using Microsoft.EntityFrameworkCore;

namespace Kaloom.API.UseCases.Students.GetAll
{
    public class GetAllStudentsUseCase : IGetAllStudentsUseCase
    {
        private readonly KaloomContext _context;

        public GetAllStudentsUseCase(KaloomContext context)
        {
            this._context = context;
        }

        public async Task<List<Aluno>> ExecuteAsync()
        {
            var alunos = await this._context.Alunos
                .Include(u => u.Usuario)
                .Include(u => u.TipoAluno)
                .AsNoTracking()
                .ToListAsync();
                
            return alunos;
        }
    }
}