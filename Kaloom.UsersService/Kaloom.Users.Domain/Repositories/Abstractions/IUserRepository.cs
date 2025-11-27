using Kaloom.Users.Domain.Models;

namespace Kaloom.Users.Domain.Repositories.Abstractions
{
    public interface IUserRepository
    {
        public Task<IEnumerable<Usuario>> GetAllAsync();
        public Task<Usuario?> GetByIdAsync(int id);
        public Task AddAsync(Usuario entity);
        public Task DeleteAsync(Usuario entity);
        public Task UpdateAsync(Usuario entity);
        public Task<Usuario?> GetByEmailAsync(string email);
    }
}
