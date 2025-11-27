using Kaloom.Students.Application.Factories;
using Kaloom.Students.Communication.DTOs.Responses;
using Kaloom.Students.Domain.Repositories.Abstractions;

namespace Kaloom.Students.Application.UseCases.Etecs.GetAll
{
    public class GetAllEtecsUseCase : IGetAllEtecsUseCase
    {

        private readonly IEtecRepository _etecRepository;
        private readonly IInstitutionUnitResponseFactory _etecResponseFactory;

        public GetAllEtecsUseCase(IEtecRepository etecRepository, IInstitutionUnitResponseFactory etecResponseFactory)
        {
            this._etecRepository = etecRepository;
            this._etecResponseFactory = etecResponseFactory;
        }


        public async Task<IEnumerable<EtecResponse>> ExecuteAsync()
        {
            var etecs = await this._etecRepository.GetAllAsync();

            List<EtecResponse> etecResponses = [];

            foreach (var etec in etecs)
            {
                etecResponses.Add(this._etecResponseFactory.Create<EtecResponse>(etec));
            }

            return etecResponses;
        }
    }
}
