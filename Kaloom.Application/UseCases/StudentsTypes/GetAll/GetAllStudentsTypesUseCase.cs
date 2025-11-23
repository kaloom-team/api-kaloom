using Kaloom.Application.Factories;
using Kaloom.Communication.DTOs.Responses;
using Kaloom.Domain.Repositories.Abstractions;

namespace Kaloom.Application.UseCases.StudentsTypes.GetAll
{
    public class GetAllStudentsTypesUseCase : IGetAllStudentsTypesUseCase
    {
        private readonly IStudentTypeRepository _studentTypeRepository;
        private readonly IStudentTypeResponseFactory _studentTypeResponseFactory;

        public GetAllStudentsTypesUseCase(IStudentTypeRepository studentTypeRepository, IStudentTypeResponseFactory studentTypeResponseFactory)
        {
            this._studentTypeRepository = studentTypeRepository;
            this._studentTypeResponseFactory = studentTypeResponseFactory;
        }
        public async Task<IReadOnlyList<StudentTypeResponse>> ExecuteAsync()
        {
            var tiposAlunos = await this._studentTypeRepository.GetAllAsync();

            return [.. tiposAlunos.Select(this._studentTypeResponseFactory.Create)];
        }
    }
}