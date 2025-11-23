using Kaloom.Domain.Models.Base;
using Kaloom.Communication.DTOs.Requests;

namespace Kaloom.Application.Factories
{
    public class InstitutionUnitFactory : IInstitutionUnitFactory
    {
        public T Create<T>(IInstitutionRequest request) where T : Instituicao, new()
        {
            return new T
            {
                Id = request.Id,
                NomeUnidade = request.NomeUnidade,
            };
        }
    }
}