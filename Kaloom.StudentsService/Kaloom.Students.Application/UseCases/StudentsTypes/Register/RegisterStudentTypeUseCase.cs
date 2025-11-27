using Kaloom.Students.Exceptions.ExceptionsBase;
using Kaloom.Students.Application.Factories;
using Kaloom.Students.Communication.DTOs.Requests;
using Kaloom.Students.Communication.DTOs.Responses;
using Kaloom.Students.Domain.Repositories.Abstractions;
using static Kaloom.Students.Application.UseCases.StudentsTypes.Utils.StudentTypeValidate;

namespace Kaloom.Students.Application.UseCases.StudentsTypes.Register
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