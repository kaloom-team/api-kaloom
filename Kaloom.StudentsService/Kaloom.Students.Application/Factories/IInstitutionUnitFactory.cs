using Kaloom.Students.Communication.DTOs.Requests;
using Kaloom.Students.Domain.Models.Base;

namespace Kaloom.Students.Application.Factories
{
    public interface IInstitutionUnitFactory
    {
        public T Create<T>(IInstitutionRequest request) where T : Instituicao, new();
    }
}
