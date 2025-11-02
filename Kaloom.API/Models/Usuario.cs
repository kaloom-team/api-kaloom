using System.Text.Json.Serialization;

namespace Kaloom.API.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;

        [JsonIgnore]
        public Aluno Aluno { get; set; }
    }
}
