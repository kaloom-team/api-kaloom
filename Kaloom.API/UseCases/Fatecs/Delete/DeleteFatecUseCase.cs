
using Kaloom.API.Context;
using Kaloom.Exceptions.ExceptionsBase;

namespace Kaloom.API.UseCases.Fatecs.Delete
{
    public class DeleteFatecUseCase : IDeleteFatecUseCase
    {
        private readonly KaloomContext _context;
        public DeleteFatecUseCase(KaloomContext context)
        {
            _context = context;
        }
        public async Task ExecuteAsync(int id)
        {
            var fatec = await this._context.Fatecs.FindAsync(id)
                ?? throw new NotFoundException($"Fatec de ID {id} não encontrada.");

            this._context.Remove(fatec);
            await this._context.SaveChangesAsync();
        }
    }
}
