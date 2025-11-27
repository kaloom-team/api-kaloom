using Kaloom.Students.Domain.Models.Base;
using System.Linq.Expressions;

namespace Kaloom.Students.Domain.Repositories.Abstractions
{
    public interface IRepositoryBase<TEntity> where TEntity : Entity
    {
        public Task<IEnumerable<TEntity>> GetAllAsync();
        public Task<TEntity?> GetByIdAsync(int id);
        public Task AddAsync(TEntity entity);
        public Task DeleteAsync(TEntity entity);
        public Task UpdateAsync(TEntity entity);
        public Task DeleteWithIncludesAsync(int id, params Expression<Func<TEntity, object>>[] includes);
        public Task<TEntity?> GetByReferenceIdAsync(Expression<Func<TEntity, bool>> predicate);
        public Task<TEntity?> GetByReferenceIdAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);
    }
}
