using Kaloom.Students.Communication.DTOs.Responses;
using Kaloom.Students.Domain.Models.Base;

namespace Kaloom.Students.Application.Factories
{
    public interface IInstitutionUnitResponseFactory
    {
        T Create<T>(Instituicao model)
        where T : IInstitutionResponse, new();
    }
}
