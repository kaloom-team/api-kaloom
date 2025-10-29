namespace Kaloom.API.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Sobrenome { get; set; } = string.Empty;
        public string NomeUsuario { get; set; } = string.Empty;
        public string FotoPerfil { get; set; } = string.Empty;
        public DateOnly DataNascimento { get; set; }
        public DateTime? DataCadastro { get; set; }

        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }

        public int IdTipoAluno { get; set; }
        public TipoAluno TipoAluno { get; set; }
    }
}
