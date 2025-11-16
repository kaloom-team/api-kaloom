using Kaloom.API.Models;
using Kaloom.Communication.DTOs.Requests;

namespace Kaloom.API.Factories
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
