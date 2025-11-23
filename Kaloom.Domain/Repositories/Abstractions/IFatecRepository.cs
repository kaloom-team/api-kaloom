using Kaloom.Domain.Models;

namespace Kaloom.Domain.Repositories.Abstractions
{
    public interface IFatecRepository
    {
        public Task<IEnumerable<Fatec>> GetAllAsync();
        public Task<Fatec?> GetByIdAsync(int id);
        public Task AddAsync(Fatec entity);
        public Task DeleteAsync(Fatec entity);
        public Task UpdateAsync(Fatec entity);
    }
}
