using Kaloom.Students.Exceptions.ExceptionsBase;
using Kaloom.Students.Application.Factories;
using Kaloom.Students.Communication.DTOs.Requests;
using Kaloom.Students.Communication.DTOs.Responses;
using Kaloom.Students.Domain.Models;
using Kaloom.Students.Domain.Repositories.Abstractions;
using static Kaloom.Students.Application.UseCases.Etecs.Utils.EtecValidate;

namespace Kaloom.Students.Application.UseCases.Etecs.Register
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