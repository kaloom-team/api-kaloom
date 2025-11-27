using Kaloom.Students.Domain.Models.Base;

namespace Kaloom.Students.Domain.Models
{
    public class Aluno : Entity
    {
        public string Nome { get; set; } = string.Empty;
        public string Sobrenome { get; set; } = string.Empty;
        public DateOnly DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }

        public int IdUsuario { get; set; }

        public int IdTipoAluno { get; set; }
        public required TipoAluno TipoAluno { get; set; }
        public List<Instituicao> Instituicoes { get; set; } = new();

    }
}
