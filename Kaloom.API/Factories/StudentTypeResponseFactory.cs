using Kaloom.API.Models;
using Kaloom.Communication.DTOs.Responses;

namespace Kaloom.API.Factories
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
