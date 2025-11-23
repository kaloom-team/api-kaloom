using Kaloom.Domain.Models;
using Kaloom.Domain.Repositories.Abstractions;
using System.Linq.Expressions;

namespace Kaloom.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IRepositoryBase<Aluno> _studentRepository;

        public StudentRepository(IRepositoryBase<Aluno> studentRepository)
        {
            this._studentRepository = studentRepository;
        }

        public async Task<IEnumerable<Aluno>> GetAllAsync()
        {
            return await this._studentRepository.GetAllAsync();
        }

        public async Task<Aluno?> GetByIdAsync(int id)
        {
            return await this._studentRepository.GetByIdAsync(id);
        }

        public async Task<Aluno?> GetByReferenceIdAsync(Expression<Func<Aluno, bool>> predicate)
        {
            return await this._studentRepository.GetByReferenceIdAsync(predicate);
        }

        public async Task<Aluno?> GetByReferenceIdAsync(Expression<Func<Aluno, bool>> predicate, params Expression<Func<Aluno, object>>[] includes)
        {
            return await this._studentRepository.GetByReferenceIdAsync(predicate, includes);
        }
       
        public async Task AddAsync(Aluno entity)
        {
            await this._studentRepository.AddAsync(entity);
        }

        public async Task UpdateAsync(Aluno entity)
        {
            await this._studentRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(Aluno entity)
        {
            await this._studentRepository.DeleteAsync(entity);
        }

        public async Task DeleteWithIncludesAsync(int id)
        {
            await this._studentRepository.DeleteWithIncludesAsync(id, a => a.Usuario);
        }
    }
}
