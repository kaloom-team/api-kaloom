using Kaloom.API.Context;
using Kaloom.API.Factories;
using Kaloom.Communication.DTOs.Responses;
using Kaloom.Exceptions.ExceptionsBase;
using Microsoft.EntityFrameworkCore;

namespace Kaloom.API.UseCases.Etecs.GetById
{
    public class GetEtecByIdUseCase : IGetEtecByIdUseCase
    {
        private readonly KaloomContext _context;
        private readonly IInstitutionUnitResponseFactory _etecResponseFactory;

        public GetEtecByIdUseCase(KaloomContext context, IInstitutionUnitResponseFactory etecResponseFactory)
        {
            this._context = context;
            this._etecResponseFactory = etecResponseFactory;
        }

        public async Task<EtecResponse> ExecuteAsync(int id)
        {
            var etec = await this._context.Etecs
               .AsNoTracking()
               .FirstOrDefaultAsync(e => e.Id == id)
               ?? throw new NotFoundException($"Nenhuma Etec encontrada com o ID {id}.");

            return this._etecResponseFactory.Create<EtecResponse>(etec);
        }
    }

}
