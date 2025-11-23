using Kaloom.Domain.Models;
using Kaloom.Domain.Repositories.Abstractions;

namespace Kaloom.Infrastructure.Repositories
{
    public class EtecRepository : IEtecRepository
    {
        private readonly IRepositoryBase<Etec> _etecRepository;

        public EtecRepository(IRepositoryBase<Etec> etecRepository)
        {
            this._etecRepository = etecRepository;
        }

        public async Task<IEnumerable<Etec>> GetAllAsync()
        {
            return await this._etecRepository.GetAllAsync();
        }

        public async Task<Etec?> GetByIdAsync(int id)
        {
            return await this._etecRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Etec entity)
        {
            await this._etecRepository.AddAsync(entity);
        }

        public async Task UpdateAsync(Etec entity)
        {
            await this._etecRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(Etec entity)
        {
            await this._etecRepository.DeleteAsync(entity);
        }
    }
}
