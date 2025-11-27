namespace Kaloom.Users.Communication.DTOs.Responses
{
    public sealed record UserResponse
    {
        public int Id { get; init; }
        public string Email { get; init; }
        public string NomeUsuario { get; init; }
        public string FotoPerfil { get; init; }
        public string FotoCapa { get; init; }
        public string Biografia { get; init; }
        public UserResponse
        (
            int Id,
            string Email,
            string NomeUsuario,
            string FotoPerfil,
            string FotoCapa,
            string Biografia
        )
        {
            this.Id = Id;
            this.Email = Email;
            this.NomeUsuario = NomeUsuario;
            this.FotoPerfil = FotoPerfil;
            this.FotoCapa = FotoCapa;
            this.Biografia = Biografia;
        }
        public UserResponse()
        {
        }
    }
}
