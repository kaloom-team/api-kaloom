using Kaloom.SharedContracts.Events;
using Kaloom.Students.Domain.Models;
using Kaloom.Students.Domain.Repositories.Abstractions;

namespace Kaloom.Students.Application.Consumers
{
    public class UserCreatedConsumer
    {
        private readonly IStudentRepository _studentRepository;
        public UserCreatedConsumer(IStudentRepository studentRepository)
        {
            this._studentRepository = studentRepository;
        }
        public async Task ConsumeAsync(UserCreatedEvent userEvent)
        {
            var novoAluno = new Aluno
            {
                Nome = userEvent.GivenName,
                Sobrenome = userEvent.FamilyName,
                IdUsuario = userEvent.UserId,
                NomeUsuario = (userEvent.GivenName + userEvent.FamilyName).Replace(" ", "").ToLower(),
                DataCadastro = DateTime.Now,
                IdTipoAluno = 1,
                TipoAluno = null,
            };

            await this._studentRepository.AddAsync(novoAluno);
        }
    }
}
