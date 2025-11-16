using Kaloom.API.Context;
using Kaloom.API.Factories;
using Kaloom.API.Models;
using Kaloom.Communication.DTOs.Requests;
using Kaloom.Communication.DTOs.Responses;
using Kaloom.Exceptions.ExceptionsBase;
using Microsoft.EntityFrameworkCore;
using static Kaloom.API.UseCases.Etecs.Utils.EtecValidate;

namespace Kaloom.API.UseCases.Etecs.Register
{
    public class RegisterEtecUseCase : IRegisterEtecUseCase
    {
        private readonly KaloomContext _context;
        private readonly IInstitutionUnitResponseFactory _etecResponseFactory;
        private readonly IInstitutionUnitFactory _etecFactory;
        public RegisterEtecUseCase(
            KaloomContext context,
            IInstitutionUnitResponseFactory etecResponseFactory,
            IInstitutionUnitFactory etecFactory)
        {
            this._context = context;
            this._etecResponseFactory = etecResponseFactory;
            this._etecFactory = etecFactory;
        }
        public async Task<EtecResponse> ExecuteAsync(EtecRequest request)
        {
            Validate(request);

            if (await this._context.Etecs
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.NomeUnidade.ToLower() == request.NomeUnidade.ToLower()) is not null)
                throw new ErrorOnValidationException("Etec já cadastrada.");

            var etec = this._etecFactory.Create<Etec>(request);

            await this._context.AddAsync(etec);
            await this._context.SaveChangesAsync();

            var response = this._etecResponseFactory.Create<EtecResponse>(etec);
            return response;
        }
    }
}