using Kaloom.Domain.Enums;
using Kaloom.Domain.Models.Base;

namespace Kaloom.Domain.Models
{
    public class TipoAluno : Entity
    {
        public bool Fatec { get; set; }
        public bool Etec { get; set; }
        public EAcademicStatus? StatusEtec { get; set; }
        public EAcademicStatus? StatusFatec { get; set; }
        public string Description { get; set; } = string.Empty;
        public ICollection<Aluno> Alunos { get; set; } = new List<Aluno>();
    }
}