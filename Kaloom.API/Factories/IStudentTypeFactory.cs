using Kaloom.API.Models;
using Kaloom.Communication.DTOs.Responses;

namespace Kaloom.API.Factories
{
    public interface IStudentTypeFactory
    {
        public StudentTypeResponse Create(TipoAluno tipoAluno);
    }
}
