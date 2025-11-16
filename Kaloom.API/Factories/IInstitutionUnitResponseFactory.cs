using Kaloom.API.Models.Base;
using Kaloom.Communication.DTOs.Responses;

namespace Kaloom.API.Factories
{
    public interface IInstitutionUnitResponseFactory
    {
        T Create<T>(Instituicao model)
        where T : IInstitutionResponse, new();
    }
}
