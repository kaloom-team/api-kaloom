using Kaloom.Communication.DTOs.Requests;
using Kaloom.Domain.Repositories.Abstractions;
using Kaloom.Exceptions.ExceptionsBase;
using static Kaloom.Application.UseCases.StudentsTypes.Utils.StudentTypeValidate;

namespace Kaloom.Application.UseCases.StudentsTypes.Update
{
    public class UpdateStudentTypeUseCase : IUpdateStudentTypeUseCase
    {
        private readonly IStudentTypeRepository _studentTypeRepository;
        public UpdateStudentTypeUseCase(IStudentTypeRepository studentTypeRepository)
        {
            this._studentTypeRepository = studentTypeRepository;
        }
        public async Task ExecuteAsync(int id, StudentTypeRequest request)
        {
            Validate(request);

            var tipoAluno = await this._studentTypeRepository.GetByIdAsync(id)
                ?? throw new NotFoundException($"Tipo de aluno com ID {id} não encontrado.");

            var studentTypes = await this._studentTypeRepository.GetAllAsync();

            if (studentTypes
                .Any(t =>
                    t.Etec == request.Etec &&
                    t.Etec == request.Etec &&
                    t.Fatec == request.Fatec &&
                    t.StatusEtec == request.StatusEtec &&
                    t.StatusFatec == request.StatusFatec &&
                    t.Id != id
                )
            )
            {
                throw new ErrorOnValidationException("Tipo de aluno já cadastrado.");
            }

            tipoAluno.Etec = request.Etec;
            tipoAluno.Fatec = request.Fatec;
            tipoAluno.StatusEtec = request.StatusEtec;
            tipoAluno.StatusFatec = request.StatusFatec;
            tipoAluno.Description = request.Description;

            await this._studentTypeRepository.UpdateAsync(tipoAluno);
        }
    }
}