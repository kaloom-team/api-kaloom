using Kaloom.Application.Factories;
using Kaloom.Communication.DTOs.Responses;
using Kaloom.Domain.Repositories.Abstractions;
using Kaloom.Exceptions.ExceptionsBase;

namespace Kaloom.Application.UseCases.StudentsTypes.GetById
{
    public class GetStudentTypeByIdUseCase : IGetStudentTypeByIdUseCase
    {
        private readonly IStudentTypeRepository _studentTypeRepository;
        private readonly IStudentTypeResponseFactory _studentTypeFactory;

        public GetStudentTypeByIdUseCase(IStudentTypeRepository studentTypeRepository, IStudentTypeResponseFactory studentTypeFactory)
        {
            this._studentTypeRepository = studentTypeRepository;
            this._studentTypeFactory = studentTypeFactory;
        }

        public async Task<StudentTypeResponse> ExecuteAsync(int id)
        {
            var tipoAluno = await this._studentTypeRepository.GetByIdAsync(id)
               ?? throw new NotFoundException($"Nenhum tipo de aluno encontrado com o ID {id}.");

            return this._studentTypeFactory.Create(tipoAluno);
        }
    }
}