using Kaloom.Students.Communication.DTOs.Responses;
using Kaloom.Students.Domain.Models.Base;

namespace Kaloom.Students.Application.Factories
{
    public class InstitutionUnitResponseFactory : IInstitutionUnitResponseFactory
    {
        public TResponse Create<TResponse>(Instituicao unit) where TResponse : IInstitutionResponse, new()
        {
            return new TResponse
            {
                Id = unit.Id,
                NomeUnidade = unit.NomeUnidade,
            };
        }
    }
}
