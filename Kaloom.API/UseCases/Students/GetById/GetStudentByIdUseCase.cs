using AutoMapper;
using Kaloom.API.Context;
using Kaloom.Communication.DTOs.Responses;
using Kaloom.Exceptions.ExceptionsBase;
using Microsoft.EntityFrameworkCore;

namespace Kaloom.API.UseCases.Students.GetById
{
    public class GetStudentByIdUseCase : IGetStudentByIdUseCase
    {
        private readonly KaloomContext _context;
        private readonly IMapper _mapper;

        public GetStudentByIdUseCase(KaloomContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<StudentResponse> ExecuteAsync(int id)
        {
            var aluno = await _context.Alunos
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id) ?? throw new NotFoundException($"Aluno com ID {id} não encontrado.");

            return _mapper.Map<StudentResponse>(aluno);
        }
    }
}