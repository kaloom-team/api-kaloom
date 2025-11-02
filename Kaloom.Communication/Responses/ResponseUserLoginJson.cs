namespace Kaloom.Communication.Responses
{
    public class ResponseUserLoginJson
    {
        public string Message { get; set; } = string.Empty;
        public object? Aluno { get; set; }

        public ResponseUserLoginJson(string msg, object? aluno)
        {
            this.Message = msg;
            this.Aluno = aluno;
        }
    }
}
