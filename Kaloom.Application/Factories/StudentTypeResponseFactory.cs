using Kaloom.Domain.Models;
using Kaloom.Communication.DTOs.Responses;

namespace Kaloom.Application.Factories
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
