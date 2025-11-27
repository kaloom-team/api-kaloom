namespace Kaloom.Users.Communication.DTOs.Responses
{
    public sealed record UserLoginResponse
    {
        public string Message { get; }
        public string Token { get; }

        public UserLoginResponse(string msg, string token)
        {
            this.Message = msg;
            this.Token = token;
        }
    }
}