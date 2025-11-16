using Kaloom.API.Models;
using Kaloom.Communication.DTOs.Responses;

namespace Kaloom.API.Factories
{
    public class StudentTypeFactory : IStudentTypeFactory
    {
        public StudentTypeResponse Create(TipoAluno tipoAluno)
        {
            return new StudentTypeResponse
            {
                Id = tipoAluno.Id,
                Fatec = tipoAluno.Fatec,
                Etec = tipoAluno.Etec
            };
        }
    }
}
