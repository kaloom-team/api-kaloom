namespace Kaloom.API.Models.Base
{
    public abstract class Instituicao
    {
        public int Id { get; set; }
        public string NomeUnidade { get; set; } = string.Empty;
    }
}
