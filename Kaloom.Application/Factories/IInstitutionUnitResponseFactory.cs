using Kaloom.Domain.Models.Base;
using Kaloom.Communication.DTOs.Responses;

namespace Kaloom.Application.Factories
{
    public interface IInstitutionUnitResponseFactory
    {
        T Create<T>(Instituicao model)
        where T : IInstitutionResponse, new();
    }
}
