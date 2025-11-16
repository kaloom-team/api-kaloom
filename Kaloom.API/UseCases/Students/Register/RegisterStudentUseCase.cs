using AutoMapper;
using Kaloom.API.Context;
using Kaloom.API.Factories;
using Kaloom.API.Models;
using Kaloom.API.UseCases.Students.Utils;
using Kaloom.Communication.DTOs.Requests;
using Kaloom.Communication.DTOs.Responses;

namespace Kaloom.API.UseCases.Students.Register
{
    public class RegisterStudentUseCase : IRegisterStudentUseCase
    {
        private readonly KaloomContext _context;
        private readonly IStudentShortFactory _studentShortFactory;
        private readonly IMapper _mapper;

        public RegisterStudentUseCase(KaloomContext context, IStudentShortFactory studentShortFactory, IMapper mapper)
        {
            this._context = context;
            this._studentShortFactory = studentShortFactory;
            this._mapper = mapper;
        }

        public async Task<StudentShortResponse> ExecuteAsync(StudentRequest request)
        {
            StudentValidate.Validate(request);

            var aluno = this._mapper.Map<Aluno>(request);

            await this._context.AddAsync(aluno);
            await this._context.SaveChangesAsync();

            return _studentShortFactory.Create(aluno);
        }
    }
}