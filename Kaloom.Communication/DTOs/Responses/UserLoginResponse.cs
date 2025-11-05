namespace Kaloom.Communication.DTOs.Responses
{
    public class UserLoginResponse
    {
        public string Message { get; set; } = string.Empty;
        public object? Aluno { get; set; }

        public UserLoginResponse(string msg, object? aluno)
        {
            this.Message = msg;
            this.Aluno = aluno;
        }
    }
}
