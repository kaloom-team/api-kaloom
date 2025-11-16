using Kaloom.API.Models.Base;
using Kaloom.Communication.DTOs.Requests;

namespace Kaloom.API.Factories
{
    public interface IInstitutionUnitFactory
    {
        public T Create<T>(IInstitutionRequest request) where T : Instituicao, new();
    }
}
