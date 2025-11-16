using Kaloom.API.Models;
using Kaloom.Communication.DTOs.Requests;

namespace Kaloom.API.Factories
{
    public interface IStudentTypeFactory
    {
        public TipoAluno Create(StudentTypeRequest request);
    }
}
