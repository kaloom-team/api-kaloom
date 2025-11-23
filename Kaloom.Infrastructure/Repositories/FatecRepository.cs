using Kaloom.Domain.Models;
using Kaloom.Domain.Repositories.Abstractions;

namespace Kaloom.Infrastructure.Repositories
{
    public class FatecRepository : IFatecRepository
    {
        private readonly IRepositoryBase<Fatec> _fatecRepository;

        public FatecRepository(IRepositoryBase<Fatec> fatecRepository)
        {
            this._fatecRepository = fatecRepository;
        }

        public async Task<IEnumerable<Fatec>> GetAllAsync()
        {
            return await this._fatecRepository.GetAllAsync();
        }

        public async Task<Fatec?> GetByIdAsync(int id)
        {
            return await this._fatecRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Fatec entity)
        {
            await this._fatecRepository.AddAsync(entity);
        }

        public async Task UpdateAsync(Fatec entity)
        {
            await this._fatecRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(Fatec entity)
        {
            await this._fatecRepository.DeleteAsync(entity);
        }
    }
}
