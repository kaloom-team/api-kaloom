namespace Kaloom.Communication.Requests
{
    public class RequestStudentJson
    {
        public string Nome { get; set; } = string.Empty;
        public string Sobrenome { get; set; } = string.Empty;
        public string NomeUsuario { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public int IdUsuario { get; set; }
        public int IdTipoAluno { get; set; }
    }
}
