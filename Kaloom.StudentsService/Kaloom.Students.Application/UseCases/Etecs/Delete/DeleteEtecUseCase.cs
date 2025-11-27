using Kaloom.Students.Exceptions.ExceptionsBase;
using Kaloom.Students.Domain.Repositories.Abstractions;

namespace Kaloom.Students.Application.UseCases.Etecs.Delete
{
    public class DeleteEtecUseCase : IDeleteEtecUseCase
    {
        private readonly IEtecRepository _etecRepository;

        public DeleteEtecUseCase(IEtecRepository etecRepository)
        {
            this._etecRepository = etecRepository;
        }

        public async Task ExecuteAsync(int id)
        {
            var entity = await this._etecRepository.GetByIdAsync(id)
                ?? throw new NotFoundException($"Etec de ID {id} não encontrada.");

            await this._etecRepository.DeleteAsync(entity);
        }
    }
}
