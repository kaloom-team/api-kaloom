namespace Kaloom.API.Models
{
    public class TipoAluno
    {
        public int Id { get; set; }
        public bool Fatec { get; set; }
        public bool Etec { get; set; }
        public EStatusAcademico? StatusEtec { get; set; }
        public EStatusAcademico? StatusFatec { get; set; }
        public string Description { get; set; } = string.Empty;
        public ICollection<Aluno> Alunos { get; set; } = new List<Aluno>();

    }

    public enum EStatusAcademico
    {
        Cursando = 1,
        Formado = 2
    }
}
