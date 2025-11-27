using Kaloom.Students.Communication.DTOs.Responses;
using Kaloom.Students.Domain.Models;

namespace Kaloom.Students.Application.Factories
{
    public class StudentShortFactory : IStudentShortFactory
    {
        public StudentShortResponse Create(Aluno aluno)
        {
            return new StudentShortResponse
            (
                aluno.Id,
                aluno.Nome,
                aluno.Sobrenome
            );
        }
    }
}