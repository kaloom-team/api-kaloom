using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kaloom.API.UseCases.Students.Delete
{
    public interface IDeleteStudentUseCase
    {
        public Task ExecuteAsync(int id);
    }
}