using Kaloom.Students.Domain.Models.Base;
using Kaloom.Students.Domain.Models;
using System.Linq.Expressions;

namespace Kaloom.Students.Domain.Repositories.Abstractions
{
    public interface IStudentRepository
    {
        public Task<IEnumerable<Aluno>> GetAllAsync();
        public Task<Aluno?> GetByIdAsync(int id);
        public Task AddAsync(Aluno entity);
        public Task UpdateAsync(Aluno entity);
        public Task DeleteAsync(Aluno entity);
        public Task<Aluno?> GetByReferenceIdAsync(Expression<Func<Aluno, bool>> predicate);
        public Task<Aluno?> GetByReferenceIdAsync(Expression<Func<Aluno, bool>> predicate, params Expression<Func<Aluno, object>>[] includes);
    }
}