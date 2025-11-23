using Kaloom.Application.Factories;
using Kaloom.Communication.DTOs.Responses;
using Kaloom.Domain.Repositories.Abstractions;
using Kaloom.Exceptions.ExceptionsBase;

namespace Kaloom.Application.UseCases.Etecs.GetById
{
    public class GetEtecByIdUseCase : IGetEtecByIdUseCase
    {
        private readonly IEtecRepository _etecRepository;
        private readonly IInstitutionUnitResponseFactory _etecResponseFactory;

        public GetEtecByIdUseCase(IEtecRepository etecRepository, IInstitutionUnitResponseFactory etecResponseFactory)
        {
            this._etecRepository = etecRepository;
            this._etecResponseFactory = etecResponseFactory;
        }

        public async Task<EtecResponse> ExecuteAsync(int id)
        {
            var etec = await this._etecRepository.GetByIdAsync(id)
               ?? throw new NotFoundException($"Nenhuma Etec encontrada com o ID {id}.");

            return this._etecResponseFactory.Create<EtecResponse>(etec);
        }
    }

}
