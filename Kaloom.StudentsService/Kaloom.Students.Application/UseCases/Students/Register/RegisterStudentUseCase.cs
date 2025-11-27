using AutoMapper;
using Kaloom.Students.Application.Factories;
using Kaloom.Students.Application.UseCases.Students.Utils;
using Kaloom.Students.Communication.DTOs.Requests;
using Kaloom.Students.Communication.DTOs.Responses;
using Kaloom.Students.Domain.Models;
using Kaloom.Students.Domain.Repositories.Abstractions;
using Kaloom.Students.Exceptions.ExceptionsBase;

namespace Kaloom.Students.Application.UseCases.Students.Register
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



            var aluno = this._mapper.Map<Aluno>(request);

            await this._studentRepository.AddAsync(aluno);

            return this._studentShortFactory.Create(aluno);
        }
    }
}