using Kaloom.API.Context;
using Kaloom.API.Factories;
using Kaloom.Communication.DTOs.Responses;
using Microsoft.EntityFrameworkCore;

namespace Kaloom.API.UseCases.StudentsTypes.GetAll
{
    public class GetAllStudentsTypesUseCase : IGetAllStudentsTypesUseCase
    {
        private readonly KaloomContext _context;
        private readonly IStudentTypeResponseFactory _studentTypeResponseFactory;

        public GetAllStudentsTypesUseCase(KaloomContext context, IStudentTypeResponseFactory studentTypeResponseFactory)
        {
            this._context = context;
            this._studentTypeResponseFactory = studentTypeResponseFactory;
        }
        public async Task<IReadOnlyList<StudentTypeResponse>> ExecuteAsync()
        {
            var tiposAlunos = await this._context.TipoAlunos
                .AsNoTracking()
                .ToListAsync();

            return [.. tiposAlunos.Select(this._studentTypeResponseFactory.Create)];
        }
    }
}