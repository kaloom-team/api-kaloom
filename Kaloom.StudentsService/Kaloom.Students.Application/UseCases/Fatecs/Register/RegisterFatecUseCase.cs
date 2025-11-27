using Kaloom.Students.Exceptions.ExceptionsBase;
using Kaloom.Students.Application.Factories;
using Kaloom.Students.Communication.DTOs.Requests;
using Kaloom.Students.Communication.DTOs.Responses;
using Kaloom.Students.Domain.Models;
using Kaloom.Students.Domain.Repositories.Abstractions;
using static Kaloom.Students.Application.UseCases.Fatecs.Utils.FatecValidate;

namespace Kaloom.Students.Application.UseCases.Fatecs.Register
{
    public class RegisterFatecUseCase : IRegisterFatecUseCase
    {
        private readonly IFatecRepository _fatecRepository;
        private readonly IInstitutionUnitResponseFactory _fatecResponseFactory;
        private readonly IInstitutionUnitFactory _fatecFactory;
        public RegisterFatecUseCase(
            IFatecRepository fatecRepository,
            IInstitutionUnitResponseFactory fatecResponseFactory,
            IInstitutionUnitFactory fatecFactory)
        {
            this._fatecRepository = fatecRepository;
            this._fatecResponseFactory = fatecResponseFactory;
            this._fatecFactory = fatecFactory;
        }
        public async Task<FatecResponse> ExecuteAsync(FatecRequest request)
        {
            Validate(request);

            var fatecs = await this._fatecRepository.GetAllAsync();

            if (fatecs.Any(e => e.NomeUnidade.ToLower() == request.NomeUnidade.ToLower()))
            {
                throw new ErrorOnValidationException("Fatec já cadastrada.");
            }

            var fatec = this._fatecFactory.Create<Fatec>(request);

            await this._fatecRepository.AddAsync(fatec);

            var response = this._fatecResponseFactory.Create<FatecResponse>(fatec);
            return response;
        }
    }
}