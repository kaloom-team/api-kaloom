using Kaloom.Students.Application.UseCases.Students.Utils;
using Kaloom.Students.Communication.DTOs.Requests;
using Kaloom.Students.Domain.Repositories.Abstractions;
using Kaloom.Students.Exceptions.ExceptionsBase;

namespace Kaloom.Students.Application.UseCases.Students.Update
{
    public class UpdateStudentUseCase : IUpdateStudentUseCase
    {
        private readonly IStudentRepository _studentRepository;
        public UpdateStudentUseCase(IStudentRepository studentRepository)
        {
            this._studentRepository = studentRepository;
        }
        public async Task ExecuteAsync(int id, StudentRequest request)
        {
            StudentValidate.Validate(request);

            var aluno = await this._studentRepository.GetByIdAsync(id)
                ?? throw new NotFoundException($"Aluno com ID {id} não encontrado.");

            var alunos = await this._studentRepository.GetAllAsync();

            

            aluno.Nome = request.Nome;
            aluno.Sobrenome = request.Sobrenome;
            aluno.DataNascimento = request.DataNascimento;

            await this._studentRepository.UpdateAsync(aluno);
        }
    }
}