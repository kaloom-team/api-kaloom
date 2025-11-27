using Kaloom.Students.Communication.DTOs.Responses;
using Kaloom.Students.Domain.Models;

namespace Kaloom.Students.Application.Factories
{
    public interface IStudentTypeResponseFactory
    {
        public StudentTypeResponse Create(TipoAluno tipoAluno);
    }
}
