using Kaloom.Communication.Enums;

namespace Kaloom.API.Models
{
    public class TipoAluno
    {
        public int Id { get; set; }
        public bool Fatec { get; set; }
        public bool Etec { get; set; }
        public EAcademicStatus? StatusEtec { get; set; }
        public EAcademicStatus? StatusFatec { get; set; }
        public string Description { get; set; } = string.Empty;
        public ICollection<Aluno> Alunos { get; set; } = new List<Aluno>();
    }
}