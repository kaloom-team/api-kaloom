using Kaloom.Domain.Models;
using Kaloom.Communication.DTOs.Responses;

namespace Kaloom.Application.Factories
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