using Kaloom.Application.Factories;
using Kaloom.Communication.DTOs.Requests;
using Kaloom.Communication.DTOs.Responses;
using Kaloom.Domain.Models;
using Kaloom.Domain.Repositories.Abstractions;
using Kaloom.Exceptions.ExceptionsBase;
using static Kaloom.Application.UseCases.Etecs.Utils.EtecValidate;

namespace Kaloom.Application.UseCases.Etecs.Register
{
    public class RegisterEtecUseCase : IRegisterEtecUseCase
    {
        private readonly IEtecRepository _etecRepository;
        private readonly IInstitutionUnitResponseFactory _etecResponseFactory;
        private readonly IInstitutionUnitFactory _etecFactory;
        public RegisterEtecUseCase(
            IEtecRepository etecRepository,
            IInstitutionUnitResponseFactory etecResponseFactory,
            IInstitutionUnitFactory etecFactory)
        {
            this._etecRepository = etecRepository;
            this._etecResponseFactory = etecResponseFactory;
            this._etecFactory = etecFactory;
        }
        public async Task<EtecResponse> ExecuteAsync(EtecRequest request)
        {
            Validate(request);

            var etecs = await _etecRepository.GetAllAsync();

            if (etecs.Any(e => e.NomeUnidade.ToLower() == request.NomeUnidade.ToLower()))
            {
                throw new ErrorOnValidationException("Etec já cadastrada.");
            }

            var etec = this._etecFactory.Create<Etec>(request);

            await this._etecRepository.AddAsync(etec);

            var response = this._etecResponseFactory.Create<EtecResponse>(etec);
            return response;
        }
    }
}