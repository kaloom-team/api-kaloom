using Kaloom.API.Models;
using Kaloom.Communication.DTOs.Responses;

namespace Kaloom.API.Factories
{
    public interface IStudentTypeResponseFactory
    {
        public StudentTypeResponse Create(TipoAluno tipoAluno);
    }
}
