using Kaloom.API.Context;
using Kaloom.Communication.DTOs.Requests;
using Kaloom.Exceptions.ExceptionsBase;
using Microsoft.EntityFrameworkCore;
using static Kaloom.API.UseCases.Etecs.Utils.EtecValidate;

namespace Kaloom.API.UseCases.Etecs.Update
{
    public class UpdateEtecUseCase : IUpdateEtecUseCase
    {
        private readonly KaloomContext _context;
        public UpdateEtecUseCase(KaloomContext context)
        {
            this._context = context;
        }
        public async Task ExecuteAsync(int id, EtecRequest request)
        {
            Validate(request);

            var etec = await this._context.Etecs.FindAsync(id) 
                ?? throw new NotFoundException($"Etec com ID {id} não encontrada.");

            if (await this._context.Etecs
                .AsNoTracking()
                .AnyAsync(e => e.NomeUnidade.ToLower() == request.NomeUnidade.ToLower() && e.Id != id))
            {
                throw new ErrorOnValidationException("Etec já cadastrada.");
            }

            etec.NomeUnidade = request.NomeUnidade;

            this._context.Update(etec);
            await _context.SaveChangesAsync();
        }
    }
}