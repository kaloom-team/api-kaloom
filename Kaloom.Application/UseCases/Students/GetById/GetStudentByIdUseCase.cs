using AutoMapper;
using Kaloom.Communication.DTOs.Responses;
using Kaloom.Domain.Repositories.Abstractions;
using Kaloom.Exceptions.ExceptionsBase;

namespace Kaloom.Application.UseCases.Students.GetById
{
    public class GetStudentByIdUseCase : IGetStudentByIdUseCase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public GetStudentByIdUseCase(IStudentRepository studentRepository, IMapper mapper)
        {
            this._studentRepository = studentRepository;
            this._mapper = mapper;
        }

        public async Task<StudentResponse> ExecuteAsync(int id)
        {
            var aluno = await this._studentRepository.GetByIdAsync(id)
                ?? throw new NotFoundException($"Aluno com ID {id} não encontrado.");

            return this._mapper.Map<StudentResponse>(aluno);
        }
    }
}