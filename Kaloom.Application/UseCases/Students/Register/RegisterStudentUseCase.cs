using AutoMapper;
using Kaloom.Application.Factories;
using Kaloom.Application.UseCases.Students.Utils;
using Kaloom.Communication.DTOs.Requests;
using Kaloom.Communication.DTOs.Responses;
using Kaloom.Domain.Models;
using Kaloom.Domain.Repositories.Abstractions;
using Kaloom.Exceptions.ExceptionsBase;

namespace Kaloom.Application.UseCases.Students.Register
{
    public class RegisterStudentUseCase : IRegisterStudentUseCase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IStudentShortFactory _studentShortFactory;
        private readonly IMapper _mapper;

        public RegisterStudentUseCase(IStudentRepository studentRepository, IStudentShortFactory studentShortFactory, IMapper mapper)
        {
            this._studentRepository = studentRepository;
            this._studentShortFactory = studentShortFactory;
            this._mapper = mapper;
        }

        public async Task<StudentShortResponse> ExecuteAsync(StudentRequest request)
        {
            StudentValidate.Validate(request);

            var alunos = await this._studentRepository.GetAllAsync();

            if (alunos.Any(e => e.NomeUsuario.ToLower() == request.NomeUsuario.ToLower() && e.Id != request.Id))
            {
                throw new ErrorOnValidationException("Nome de usuário já em uso.");
            }

            var aluno = this._mapper.Map<Aluno>(request);

            await this._studentRepository.AddAsync(aluno);

            return this._studentShortFactory.Create(aluno);
        }
    }
}