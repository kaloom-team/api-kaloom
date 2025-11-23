using Kaloom.Domain.Models;
using Kaloom.Domain.Repositories.Abstractions;

namespace Kaloom.Infrastructure.Repositories
{
    public class StudentTypeRepository : IStudentTypeRepository
    {
        private readonly IRepositoryBase<TipoAluno> _studentTypeRepository;

        public StudentTypeRepository(IRepositoryBase<TipoAluno> studentTypeRepository)
        {
            this._studentTypeRepository = studentTypeRepository;
        }

        public async Task<IEnumerable<TipoAluno>> GetAllAsync()
        {
            return await this._studentTypeRepository.GetAllAsync();
        }

        public async Task<TipoAluno?> GetByIdAsync(int id)
        {
            return await this._studentTypeRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(TipoAluno entity)
        {
            await this._studentTypeRepository.AddAsync(entity);
        }

        public async Task UpdateAsync(TipoAluno entity)
        {
            await this._studentTypeRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(TipoAluno entity)
        {
            await this._studentTypeRepository.DeleteAsync(entity);
        }
    }
}
