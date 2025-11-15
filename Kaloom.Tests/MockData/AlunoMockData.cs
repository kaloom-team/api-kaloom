using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kaloom.API.Models;
using Kaloom.Communication.DTOs.Responses;


namespace Kaloom.Tests.MockData
{
    public class AlunoMockData
    {
        public static IEnumerable<StudentResponse> GetAll()
        {
            return new List<StudentResponse>
            {
                new StudentResponse{  
                    Nome = "André",
                    Sobrenome = "Melchior",
                    NomeUsuario = "andremelchior",
                    DataNascimento = DateOnly.Parse("2003-05-05"),
                    DataCadastro = DateTime.Now,
                    IdTipoAluno = 2,
                    IdUsuario = 1,
                },
                new StudentResponse{
                    Nome = "Alisson",
                    Sobrenome = "Ruan",
                    NomeUsuario = "alisson.ruan",
                    DataNascimento = DateOnly.Parse("2005-07-02"),
                    DataCadastro = DateTime.Now,
                    IdTipoAluno = 2,
                    IdUsuario = 2,
                }
            };
        }

        public static StudentResponse GetById(int id)
        {
            return new StudentResponse { Id = id };
        }
    }
}
