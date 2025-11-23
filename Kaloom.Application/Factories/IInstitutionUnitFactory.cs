using Kaloom.Domain.Models.Base;
using Kaloom.Communication.DTOs.Requests;

namespace Kaloom.Application.Factories
{
    public interface IInstitutionUnitFactory
    {
        public T Create<T>(IInstitutionRequest request) where T : Instituicao, new();
    }
}
