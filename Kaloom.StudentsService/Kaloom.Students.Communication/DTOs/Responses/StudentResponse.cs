using Kaloom.Students.Communication.DTOs.Responses;
using Kaloom.Students.Domain.Models.Base;

namespace Kaloom.Users.Communication.DTOs.Responses
{
    public sealed record StudentResponse
    {
        public int Id { get; init; }
        public string Nome { get; init; }
        public DateOnly DataNascimento { get; init; }
        public DateTime? DataCadastro { get; init; }
        public int IdUsuario { get; init; }
        public int IdTipoAluno { get; init; }
        public IReadOnlyList<Instituicao> Instituicoes { get; init; } = Array.Empty<Instituicao>();


        public StudentResponse() 
        { 
        }
        public StudentResponse(
            int Id,
            string Nome,
            DateOnly DataNascimento,
            DateTime? DataCadastro,
            int IdUsuario,
            int IdTipoAluno,
            IReadOnlyList<Instituicao> Instituicoes
        )
        {
            this.Id = Id;
            this.Nome = Nome;
            this.DataNascimento = DataNascimento;
            this.DataCadastro = DataCadastro;
            this.IdUsuario = IdUsuario;
            this.IdTipoAluno = IdTipoAluno;
            this.Instituicoes = Instituicoes;
        }
    }
    
}
