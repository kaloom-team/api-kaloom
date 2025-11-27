using Kaloom.Students.Exceptions.ExceptionsBase;
using Kaloom.Students.Domain.Repositories.Abstractions;

namespace Kaloom.Students.Application.UseCases.Fatecs.Delete
{
    public class DeleteFatecUseCase : IDeleteFatecUseCase
    {
        private readonly IFatecRepository _fatecRepository;

        public DeleteFatecUseCase(IFatecRepository fatecRepository)
        {
            this._fatecRepository = fatecRepository;
        }
        public async Task ExecuteAsync(int id)
        {
            var entity = await this._fatecRepository.GetByIdAsync(id)
                ?? throw new NotFoundException($"Fatec de ID {id} não encontrada.");

            await this._fatecRepository.DeleteAsync(entity);
        }
    }
}