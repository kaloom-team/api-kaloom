using Kaloom.Application.Factories;
using Kaloom.Communication.DTOs.Requests;
using Kaloom.Communication.DTOs.Responses;
using Kaloom.Domain.Repositories.Abstractions;
using Kaloom.Exceptions.ExceptionsBase;
using static Kaloom.Application.UseCases.StudentsTypes.Utils.StudentTypeValidate;

namespace Kaloom.Application.UseCases.StudentsTypes.Register
{
    public class RegisterStudentTypeUseCase : IRegisterStudentTypeUseCase
    {
        private readonly IStudentTypeRepository _studentTypeRepository;
        private readonly IStudentTypeFactory _studentTypeFactory;
        private readonly IStudentTypeResponseFactory _studentTypeResponseFactory;
        public RegisterStudentTypeUseCase(
            IStudentTypeRepository studentTypeRepository,
            IStudentTypeFactory studentTypeFactory,
            IStudentTypeResponseFactory studentTypeResponseFactory)
        {
            this._studentTypeRepository = studentTypeRepository;
            this._studentTypeFactory = studentTypeFactory;
            this._studentTypeResponseFactory = studentTypeResponseFactory;
        }
        public async Task<StudentTypeResponse> ExecuteAsync(StudentTypeRequest request)
        {
            Validate(request);

            var studentTypes = await this._studentTypeRepository.GetAllAsync();

            if (studentTypes
                .Any(t =>
                    t.Etec == request.Etec &&
                    t.Fatec == request.Fatec &&
                    t.StatusEtec == request.StatusEtec &&
                    t.StatusFatec == request.StatusFatec
                )
            )
            {
                throw new ErrorOnValidationException("Tipo de aluno já cadastrado.");
            }

            var tipoAluno = this._studentTypeFactory.Create(request);

            await this._studentTypeRepository.AddAsync(tipoAluno);

            var response = this._studentTypeResponseFactory.Create(tipoAluno);
            return response;
        }
    }
}