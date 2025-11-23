using Kaloom.Domain.Models;
using Kaloom.Domain.Models.Base;
using Kaloom.Domain.Repositories.Abstractions;
using Kaloom.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Kaloom.Infrastructure.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : Entity
    {
        public readonly DbSet<TEntity> _DbSet;
        public readonly KaloomContext _context;

        public RepositoryBase(KaloomContext appContext)
        {
            this._DbSet = appContext.Set<TEntity>();
            this._context = appContext;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var query = this._DbSet.AsQueryable();

            return await query
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(int id)
        {
            return await this._DbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<TEntity?> GetByReferenceIdAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await this._DbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(predicate);
        }

        public async Task<TEntity?> GetByReferenceIdAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = this._DbSet.AsQueryable();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return await query
                .AsNoTracking()
                .FirstOrDefaultAsync(predicate);
        }

        public async Task AddAsync(TEntity entity)
        {
            await this._DbSet.AddAsync(entity);
            await this._context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            this._DbSet.Remove(entity);
            await this._context.SaveChangesAsync();
        }

        public async Task DeleteWithIncludesAsync(int id, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = this._DbSet.AsQueryable();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            var entity = await query.FirstOrDefaultAsync(e => e.Id == id);

            if (entity == null) return;

            this._DbSet.Remove(entity);
            await this._context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            this._DbSet.Update(entity);
            await this._context.SaveChangesAsync();
        }


    }
}
