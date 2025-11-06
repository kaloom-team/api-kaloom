using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kaloom.API.Models;

namespace Kaloom.API.UseCases.Students.GetById
{
    public interface IGetStudentByIdUseCase
    {
        public Task<Aluno> ExecuteAsync(int id);
    }
}