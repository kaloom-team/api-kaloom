namespace KaloomAPI.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string NomeUsuario { get; set; }
        public string FotoPerfil { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }

        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }

        public int IdTipoAluno { get; set; }
        public TipoAluno TipoAluno { get; set; }

    }
}
