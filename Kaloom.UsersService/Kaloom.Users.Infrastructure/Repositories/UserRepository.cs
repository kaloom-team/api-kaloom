using Kaloom.Users.Domain.Models;
using Kaloom.Users.Domain.Repositories.Abstractions;

namespace Kaloom.Users.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IRepositoryBase<Usuario> _userRepository;

        public UserRepository(IRepositoryBase<Usuario> repositoryBase)
        {
            this._userRepository = repositoryBase;
        }

        public async Task AddAsync(Usuario entity)
        {
            await this._userRepository.AddAsync(entity);
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await this._userRepository.GetAllAsync();
        }

        public async Task<Usuario?> GetByIdAsync(int id)
        {
            return await this._userRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Usuario entity)
        {
            await this._userRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(Usuario entity)
        {
            await this._userRepository.DeleteAsync(entity);
        }

        public async Task<Usuario?> GetByEmailAsync(string email)
        {
            return await _userRepository.GetByReferenceIdAsync(u => u.Email == email);
        }

    }
}
