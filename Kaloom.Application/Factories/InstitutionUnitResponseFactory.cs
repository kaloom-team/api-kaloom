using Kaloom.Domain.Models.Base;
using Kaloom.Communication.DTOs.Responses;

namespace Kaloom.Application.Factories
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
