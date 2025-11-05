namespace Kaloom.Communication.DTOs.Requests
{
    public class UserLoginRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
    }
}
