namespace Kaloom.Communication.DTOs.Responses
{
    public sealed record UserLoginResponse
    {
        public string Message { get; }
        public StudentResponse? Student { get; }

        public UserLoginResponse(string msg, StudentResponse? student)
        {
            this.Message = msg;
            this.Student = student;
        }
    }
}