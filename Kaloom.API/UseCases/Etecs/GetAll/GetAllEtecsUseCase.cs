using Kaloom.API.Context;
using Kaloom.API.Factories;
using Kaloom.API.Models;
using Kaloom.Communication.DTOs.Responses;
using Kaloom.Exceptions.ExceptionsBase;
using Microsoft.EntityFrameworkCore;

namespace Kaloom.API.UseCases.Etecs.GetAll
{
    public class GetAllEtecsUseCase : IGetAllEtecsUseCase
    {
        private readonly KaloomContext _context;
        private readonly IInstitutionUnitResponseFactory _etecResponseFactory;

        public GetAllEtecsUseCase(KaloomContext context, IInstitutionUnitResponseFactory etecResponseFactory)
        {
            this._context = context;
            this._etecResponseFactory = etecResponseFactory;
        }

        public async Task<IEnumerable<EtecResponse>> ExecuteAsync()
        {
            var etecs = await this._context.Etecs
                .AsNoTracking()
                .ToListAsync();

            List<EtecResponse> etecResponses = [];

            foreach (var etec in etecs)
            {
                etecResponses.Add(this._etecResponseFactory.Create<EtecResponse>(etec));
            }

            return etecResponses;
        }
    }
}
