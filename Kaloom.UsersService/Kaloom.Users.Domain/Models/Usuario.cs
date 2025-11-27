using Kaloom.Users.Domain.Models.Base;

namespace Kaloom.Users.Domain.Models
{
    public class Usuario : Entity
    {
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public string NomeUsuario { get; set; } = string.Empty;
        public string FotoPerfil { get; set; } = string.Empty;
        public string FotoCapa { get; set; } = string.Empty;
        public string Biografia { get; set; } = string.Empty;

    }
}
