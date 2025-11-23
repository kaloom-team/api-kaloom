using Kaloom.Domain.Models;

namespace Kaloom.Domain.Repositories.Abstractions
{
    public interface IEtecRepository
    {
        public Task<IEnumerable<Etec>> GetAllAsync();
        public Task<Etec?> GetByIdAsync(int id);
        public Task AddAsync(Etec entity);
        public Task DeleteAsync(Etec entity);
        public Task UpdateAsync(Etec entity);
    }
}