using Kaloom.Students.Communication.DTOs.Responses;
using Kaloom.Students.Domain.Models;

namespace Kaloom.Students.Application.Factories
{
    public class StudentTypeResponseFactory : IStudentTypeResponseFactory
    {
        public StudentTypeResponse Create(TipoAluno tipoAluno)
        {
            return new StudentTypeResponse
            (
                tipoAluno.Id,
                tipoAluno.Fatec,
                tipoAluno.Etec,
                tipoAluno.StatusEtec,
                tipoAluno.StatusFatec,
                tipoAluno.Description
            );
        }
    }
}
