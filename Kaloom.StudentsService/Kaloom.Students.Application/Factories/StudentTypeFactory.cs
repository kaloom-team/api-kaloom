using Kaloom.Students.Communication.DTOs.Requests;
using Kaloom.Students.Domain.Models;

namespace Kaloom.Students.Application.Factories
{
    public class StudentTypeFactory : IStudentTypeFactory
    {
        public TipoAluno Create(StudentTypeRequest request)
        {
            return new TipoAluno
            {
                Fatec = request.Fatec,
                Etec = request.Etec,
                StatusFatec = request.StatusFatec,
                StatusEtec = request.StatusEtec,
                Description = request.Description
            };
        }
    }
}
