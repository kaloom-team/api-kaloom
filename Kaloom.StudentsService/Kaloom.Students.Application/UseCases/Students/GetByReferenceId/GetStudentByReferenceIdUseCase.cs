using Kaloom.SharedContracts.DTOs;
using Kaloom.Students.Domain.Models;
using Kaloom.Students.Domain.Repositories.Abstractions;
using Kaloom.Students.Exceptions.ExceptionsBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Kaloom.Students.Application.UseCases.Students.GetByReferenceId
{
    public class GetStudentByReferenceIdUseCase : IGetStudentByReferenceIdUseCase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        public GetStudentByReferenceIdUseCase(IStudentRepository studentRepository, IMapper mapper)
        {
            this._studentRepository = studentRepository;
            this._mapper = mapper;
        }
        public async Task<StudentResponse?> ExecuteAsync(int userId)
        {
            var aluno = await this._studentRepository.GetByReferenceIdAsync(a => a.IdUsuario == userId,
                    a => a.TipoAluno) 
                ?? throw new NotFoundException($"Aluno associado a usuário de ID {userId} não encontrado.");

            return this._mapper.Map<StudentResponse>(aluno);
        }
    }
}
