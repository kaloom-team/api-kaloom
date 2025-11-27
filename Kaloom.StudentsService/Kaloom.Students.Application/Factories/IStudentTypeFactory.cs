using Kaloom.Students.Communication.DTOs.Requests;
using Kaloom.Students.Domain.Models;

namespace Kaloom.Students.Application.Factories
{
    public interface IStudentTypeFactory
    {
        public TipoAluno Create(StudentTypeRequest request);
    }
}
