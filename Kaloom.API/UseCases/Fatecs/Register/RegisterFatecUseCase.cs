using Kaloom.API.Context;
using Kaloom.API.Factories;
using Kaloom.API.Models;
using Kaloom.Communication.DTOs.Requests;
using Kaloom.Communication.DTOs.Responses;
using Kaloom.Exceptions.ExceptionsBase;
using Microsoft.EntityFrameworkCore;
using static Kaloom.API.UseCases.Fatecs.Utils.FatecValidate;

namespace Kaloom.API.UseCases.Fatecs.Register
{
    public class RegisterFatecUseCase : IRegisterFatecUseCase
    {
        private readonly KaloomContext _context;
        private readonly IInstitutionUnitResponseFactory _fatecResponseFactory;
        private readonly IInstitutionUnitFactory _fatecFactory;
        public RegisterFatecUseCase(
            KaloomContext context,
            IInstitutionUnitResponseFactory fatecResponseFactory,
            IInstitutionUnitFactory fatecFactory)
        {
            this._context = context;
            this._fatecResponseFactory = fatecResponseFactory;
            this._fatecFactory = fatecFactory;
        }
        public async Task<FatecResponse> ExecuteAsync(FatecRequest request)
        {
            Validate(request);

            if (await this._context.Fatecs
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.NomeUnidade.ToLower() == request.NomeUnidade.ToLower()) is not null)
                throw new ErrorOnValidationException("Fatec já cadastrada.");

            var fatec = this._fatecFactory.Create<Fatec>(request);

            await this._context.AddAsync(fatec);
            await this._context.SaveChangesAsync();

            var response = this._fatecResponseFactory.Create<FatecResponse>(fatec);
            return response;
        }
    }
}