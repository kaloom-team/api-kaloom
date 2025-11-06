using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kaloom.API.Models;

namespace Kaloom.API.UseCases.Students.GetAll
{
    public interface IGetAllStudentsUseCase
    {
        public Task<List<Aluno>> ExecuteAsync();
    }
}