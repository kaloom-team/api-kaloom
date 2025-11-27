namespace Kaloom.Users.Communication.DTOs.Requests
{
    public class UserRequest
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public string NomeUsuario { get; set; } = string.Empty;
        public string FotoPerfil { get; set; } = string.Empty;
        public string FotoCapa { get; set; } = string.Empty;
        public string Biografia { get; set; } = string.Empty;
    }
}