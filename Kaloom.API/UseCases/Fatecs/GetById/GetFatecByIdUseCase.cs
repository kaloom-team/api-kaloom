using Kaloom.API.Context;
using Kaloom.API.Factories;
using Kaloom.Communication.DTOs.Responses;
using Kaloom.Exceptions.ExceptionsBase;
using Microsoft.EntityFrameworkCore;

namespace Kaloom.API.UseCases.Fatecs.GetById
{
    public class GetFatecByIdUseCase : IGetFatecByIdUseCase
    {
        private readonly KaloomContext _context;
        private readonly IInstitutionUnitResponseFactory _fatecResponseFactory;

        public GetFatecByIdUseCase(KaloomContext context, IInstitutionUnitResponseFactory fatecResponseFactory)
        {
            this._context = context;
            this._fatecResponseFactory = fatecResponseFactory;
        }

        public async Task<FatecResponse> ExecuteAsync(int id)
        {
            var fatec = await this._context.Fatecs
               .AsNoTracking()
               .FirstOrDefaultAsync(e => e.Id == id)
               ?? throw new NotFoundException($"Nenhuma Etec encontrada com o ID {id}.");

            return this._fatecResponseFactory.Create<FatecResponse>(fatec);
        }
    }
}
