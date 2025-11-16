using Kaloom.API.Context;
using Kaloom.API.Factories;
using Kaloom.Communication.DTOs.Responses;
using Microsoft.EntityFrameworkCore;

namespace Kaloom.API.UseCases.Fatecs.GetAll
{
    public class GetAllFatecsUseCase : IGetAllFatecsUseCase
    {
        private readonly KaloomContext _context;
        private readonly IInstitutionUnitResponseFactory _fatecResponseFactory;

        public GetAllFatecsUseCase(KaloomContext context, IInstitutionUnitResponseFactory fatecResponseFactory)
        {
            this._context = context;
            this._fatecResponseFactory = fatecResponseFactory;
        }
        public async Task<IEnumerable<FatecResponse>> ExecuteAsync()
        {
            var fatecs = await this._context.Fatecs
                .AsNoTracking()
                .ToListAsync();

            return fatecs
                .Select(_fatecResponseFactory.Create<FatecResponse>)
                .ToList();
        }
    }
}