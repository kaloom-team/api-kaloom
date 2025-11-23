using Kaloom.Domain.Repositories.Abstractions;
using Kaloom.Exceptions.ExceptionsBase;

namespace Kaloom.Application.UseCases.StudentsTypes.Delete
{
    public class DeleteStudentTypeUseCase : IDeleteStudentTypeUseCase
    {
        private readonly IStudentTypeRepository _studentTypeRepository;

        public DeleteStudentTypeUseCase(IStudentTypeRepository studentTypeRepository)
        {
            this._studentTypeRepository = studentTypeRepository;
        }

        public async Task ExecuteAsync(int id)
        {
            var tipoAluno = await this._studentTypeRepository.GetByIdAsync(id)
                ?? throw new NotFoundException($"Tipo de aluno de ID {id} não encontrado.");

            await this._studentTypeRepository.DeleteAsync(tipoAluno);
        }
    }
}