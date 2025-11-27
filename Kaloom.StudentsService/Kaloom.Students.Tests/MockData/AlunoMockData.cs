using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kaloom.Students.Domain.Models;
using Kaloom.Students.Communication.DTOs.Requests;
using Kaloom.Students.Communication.DTOs.Responses;
using Kaloom.SharedContracts.DTOs;


namespace Kaloom.Students.Tests.MockData
{
    public class AlunoMockData
    {
        public static IEnumerable<StudentResponse> GetAll()
        {
            return new List<StudentResponse>
            {
                new(
                    1,
                    "John",
                    "Doe",
                    "johndoe",
                    DateOnly.Parse("2003-05-05"),
                    DateTime.Now,
                    2,
                    1
                ),
                new(
                    2,
                    "Jane",
                    "Doe",
                    "jane.doe",
                    DateOnly.Parse("2005-07-02"),
                    DateTime.Now,
                    2,
                    2
                )
            };
        }

        public static StudentResponse GetById(int id)
        {
            return new StudentResponse { Id = id };
        }

        public static List<StudentResponse> GetAllShortList()
        {
            return
            [
                new StudentResponse
                {
                    Id = 1,
                    Nome = "John Doe"
                },
                new StudentResponse
                {
                    Id = 2,
                    Nome = "Jane Doe"
                }
            ];
        }

        public static StudentRequest RegisterRequest()
        {
            return new StudentRequest
            {
                Id = 1,
                Nome = "John",
                Sobrenome = "Doe",
                NomeUsuario = "johndoe",
                DataNascimento = DateOnly.Parse("2005-07-02"),
                IdUsuario = 2,
                IdTipoAluno = 2
            };
        }

        public static StudentShortResponse RegisterResponse()
        {
            return new StudentShortResponse(1, "John", "Doe");
        }

        public static StudentRequest UpdateRequest(string nome, string sobrenome)
        {
            return new StudentRequest
            {
                Nome = nome,
                Sobrenome = sobrenome
            };
        }
    }
}
