using Kaloom.API.Context;
using Kaloom.Exceptions.ExceptionsBase;

namespace Kaloom.API.UseCases.Etecs.Delete
{
    public class DeleteEtecUseCase : IDeleteEtecUseCase
    {
        private readonly KaloomContext _context;

        public DeleteEtecUseCase(KaloomContext context)
        {
            this._context = context;
        }

        public async Task ExecuteAsync(int id)
        {
            var etec = await this._context.Etecs.FindAsync(id)
                ?? throw new NotFoundException($"Etec de ID {id} não encontrada.");

            this._context.Remove(etec);
            await this._context.SaveChangesAsync();
        }
    }
}
