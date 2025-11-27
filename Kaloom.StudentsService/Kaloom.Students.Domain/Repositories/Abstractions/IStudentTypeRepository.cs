using Kaloom.Students.Domain.Models;

namespace Kaloom.Students.Domain.Repositories.Abstractions
{
    public interface IStudentTypeRepository
    {
        public Task<IEnumerable<TipoAluno>> GetAllAsync();
        public Task<TipoAluno?> GetByIdAsync(int id);
        public Task AddAsync(TipoAluno entity);
        public Task DeleteAsync(TipoAluno entity);
        public Task UpdateAsync(TipoAluno entity);
    }
}
