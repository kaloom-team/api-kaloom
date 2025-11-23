using Kaloom.Domain.Models;
using Kaloom.Communication.DTOs.Responses;

namespace Kaloom.Application.Factories
{
    public interface IStudentTypeResponseFactory
    {
        public StudentTypeResponse Create(TipoAluno tipoAluno);
    }
}
