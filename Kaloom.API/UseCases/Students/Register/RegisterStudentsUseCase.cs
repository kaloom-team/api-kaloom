using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Kaloom.API.Context;
using Kaloom.Communication.DTOs.Responses;
using Kaloom.Communication.DTOs.Requests;
using Kaloom.API.Factories;
using Kaloom.API.UseCases.Students.Utils;

namespace Kaloom.API.UseCases.Students.Register
{
    public class RegisterStudentsUseCase : IRegisterStudentsUseCase
    {
        private readonly KaloomContext _context;
        private readonly IStudentFactory _studentFactory;

        public RegisterStudentsUseCase(KaloomContext context, IStudentFactory studentFactory)
        {
            this._context = context;
            this._studentFactory = studentFactory;
        }

        public async Task<StudentResponse> ExecuteAsync(StudentRequest request)
        {
            StudentValidate.Validate(request);

            var aluno = this._studentFactory.Create(request);

            await this._context.AddAsync(aluno);
            await this._context.SaveChangesAsync();

            return new StudentResponse
            {
                Id = aluno.Id,
                Nome = aluno.Nome
            };
        }
    }
}