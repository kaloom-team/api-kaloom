using Kaloom.Students.Application.Factories;
using Kaloom.Students.Communication.DTOs.Responses;
using Kaloom.Students.Domain.Repositories.Abstractions;

namespace Kaloom.Students.Application.UseCases.StudentsTypes.GetAll
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