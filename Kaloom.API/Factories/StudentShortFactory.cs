using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kaloom.API.Models;
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
                NomeUsuario = aluno.NomeUsuario,
                DataNascimento = aluno.DataNascimento,
                Usuario = new UserResponse
                {
                    Id = aluno.Usuario.Id,
                    Email = aluno.Usuario.Email,
                },
                TipoAluno = new StudentTypeResponse
                {
                    Id = aluno.TipoAluno.Id,
                    Fatec = aluno.TipoAluno.Fatec,
                    Etec = aluno.TipoAluno.Etec
                }
            };
        }
    }
}