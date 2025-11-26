namespace Kaloom.Communication.DTOs.Responses
{
    public sealed record UserLoginResponse
    {
        public string Message { get; }
        public StudentResponse? Student { get; }
        public string Token { get; }

        public UserLoginResponse(string msg, StudentResponse? student, string token)
        {
            this.Message = msg;
            this.Student = student;
            this.Token = token;
        }
    }
}