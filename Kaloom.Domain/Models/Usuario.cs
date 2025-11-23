using Kaloom.Domain.Models.Base;

namespace Kaloom.Domain.Models
{
    public class Usuario : Entity
    {
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;

        public required Aluno Aluno { get; set; }

    }
}
