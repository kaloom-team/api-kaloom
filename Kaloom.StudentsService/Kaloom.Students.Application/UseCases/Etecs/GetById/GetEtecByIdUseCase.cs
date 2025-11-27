using Kaloom.Students.Exceptions.ExceptionsBase;
using Kaloom.Students.Application.Factories;
using Kaloom.Students.Communication.DTOs.Responses;
using Kaloom.Students.Domain.Repositories.Abstractions;

namespace Kaloom.Students.Application.UseCases.Etecs.GetById
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
