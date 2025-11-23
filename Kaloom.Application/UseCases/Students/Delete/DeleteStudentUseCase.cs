using Kaloom.Domain.Repositories.Abstractions;
using Kaloom.Exceptions.ExceptionsBase;

namespace Kaloom.Application.UseCases.Students.Delete
{
    public class DeleteStudentUseCase : IDeleteStudentUseCase
    {
        private readonly IStudentRepository _studentRepository;

        public DeleteStudentUseCase(IStudentRepository studentRepository)
        {
            this._studentRepository = studentRepository;
        }

        public async Task ExecuteAsync(int id)
        {
            var aluno = await this._studentRepository.GetByIdAsync(id)
                ?? throw new NotFoundException($"Aluno com ID {id} não encontrado.");

            await this._studentRepository.DeleteWithIncludesAsync(id);
        }
    }
}