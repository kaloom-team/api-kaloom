using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kaloom.API.Models;
using Kaloom.Communication.DTOs.Requests;
using Kaloom.Communication.DTOs.Responses;

namespace Kaloom.API.Factories
{
    public class StudentShortFactory : IStudentShortFactory
    {
        public StudentShortResponse Create(Aluno aluno)
        {
            return new StudentShortResponse
            {
                Id = aluno.Id,
                Nome = aluno.Nome,
                Sobrenome = aluno.Sobrenome,
            };
        }
    }
}