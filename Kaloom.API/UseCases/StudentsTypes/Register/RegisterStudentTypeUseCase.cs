using Kaloom.API.Context;
using Kaloom.API.Factories;
using Kaloom.Communication.DTOs.Requests;
using Kaloom.Communication.DTOs.Responses;
using Kaloom.Exceptions.ExceptionsBase;
using Microsoft.EntityFrameworkCore;
using static Kaloom.API.UseCases.StudentsTypes.Utils.StudentTypeValidate;

namespace Kaloom.API.UseCases.StudentsTypes.Register
{
    public class RegisterStudentTypeUseCase : IRegisterStudentTypeUseCase
    {
        private readonly KaloomContext _context;
        private readonly IStudentTypeFactory _studentTypeFactory;
        private readonly IStudentTypeResponseFactory _studentTypeResponseFactory;
        public RegisterStudentTypeUseCase(
            KaloomContext context,
            IStudentTypeFactory studentTypeFactory,
            IStudentTypeResponseFactory studentTypeResponseFactory)
        {
            this._context = context;
            this._studentTypeFactory = studentTypeFactory;
            this._studentTypeResponseFactory = studentTypeResponseFactory;
        }
        public async Task<StudentTypeResponse> ExecuteAsync(StudentTypeRequest request)
        {
            Validate(request);

            if (await this._context.TipoAlunos
                .AsNoTracking()
                .AnyAsync(t => 
                    t.Etec == request.Etec &&
                    t.Fatec == request.Fatec &&
                    t.StatusEtec == request.StatusEtec &&
                    t.StatusFatec == request.StatusFatec
                ))
                throw new ErrorOnValidationException("Tipo de aluno já cadastrado.");

            var tipoAluno = this._studentTypeFactory.Create(request);

            await this._context.AddAsync(tipoAluno);
            await this._context.SaveChangesAsync();

            var response = this._studentTypeResponseFactory.Create(tipoAluno);
            return response;
        }
    }
}