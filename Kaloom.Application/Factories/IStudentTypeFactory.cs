using Kaloom.Domain.Models;
using Kaloom.Communication.DTOs.Requests;

namespace Kaloom.Application.Factories
{
    public interface IStudentTypeFactory
    {
        public TipoAluno Create(StudentTypeRequest request);
    }
}
