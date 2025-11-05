using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kaloom.API.Models;
using Kaloom.Communication.DTOs.Requests;

namespace Kaloom.API.Factories
{
    public class StudentFactory : IStudentFactory
    {
        public Aluno Create(StudentRequest dto)
        {
            return new Aluno
            {
                Nome = dto.Nome,
                Sobrenome = dto.Sobrenome,
                NomeUsuario = dto.NomeUsuario,
                DataNascimento = dto.DataNascimento,
                DataCadastro = DateTime.Now,
                IdUsuario = dto.IdUsuario,
                IdTipoAluno = dto.IdTipoAluno
            };
        }
    }
}