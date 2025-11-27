namespace Kaloom.Students.Communication.DTOs.Requests
{
    public class StudentRequest
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Sobrenome { get; set; } = string.Empty;
        public string NomeUsuario { get; set; } = string.Empty;
        public DateOnly DataNascimento { get; set; }
        public int IdUsuario { get; set; }
        public int IdTipoAluno { get; set; }
    }
}
