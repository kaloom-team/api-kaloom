using AutoMapper;
using Kaloom.API.Context;
using Kaloom.Communication.DTOs.Responses;
using Microsoft.EntityFrameworkCore;

namespace Kaloom.API.UseCases.Students.GetAll
{
    public class GetAllStudentsUseCase : IGetAllStudentsUseCase
    {
        private readonly KaloomContext _context;
        private readonly IMapper _mapper;

        public GetAllStudentsUseCase(KaloomContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<StudentResponse>> ExecuteAsync()
        {
            var alunos = await this._context.Alunos
                .AsNoTracking()
                .ToListAsync();
                
            return this._mapper.Map<IEnumerable<StudentResponse>>(alunos);
        }
    }
}