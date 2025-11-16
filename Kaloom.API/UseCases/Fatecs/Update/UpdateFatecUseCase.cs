using Kaloom.API.Context;
using Kaloom.Communication.DTOs.Requests;
using Kaloom.Exceptions.ExceptionsBase;
using Microsoft.EntityFrameworkCore;
using static Kaloom.API.UseCases.Fatecs.Utils.FatecValidate;

namespace Kaloom.API.UseCases.Fatecs.Update
{
    public class UpdateFatecUseCase : IUpdateFatecUseCase
    {
        private readonly KaloomContext _context;
        public UpdateFatecUseCase(KaloomContext context)
        {
            this._context = context;
        }
        public async Task ExecuteAsync(int id, FatecRequest request)
        {
            Validate(request);

            var fatec = await this._context.Fatecs.FindAsync(id)
                ?? throw new NotFoundException($"Fatec com ID {id} não encontrada.");

            if (await this._context.Fatecs
                .AsNoTracking()
                .AnyAsync(f => f.NomeUnidade.ToLower() == request.NomeUnidade.ToLower() && f.Id != id))
            {
                throw new ErrorOnValidationException("Fatec já cadastrada.");
            }


            fatec.NomeUnidade = request.NomeUnidade;

            this._context.Update(fatec);
            await _context.SaveChangesAsync();
        }
    }
}