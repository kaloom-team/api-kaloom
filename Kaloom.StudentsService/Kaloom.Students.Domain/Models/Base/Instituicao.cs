namespace Kaloom.Students.Domain.Models.Base
{
    public abstract class Instituicao : Entity
    {
        public string NomeUnidade { get; set; } = string.Empty;
        public List<Aluno> Alunos { get; set; } = new();

    }
}
