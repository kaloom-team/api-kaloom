namespace KaloomAPI.Models
{
    public class TipoAluno
    {
        public int Id { get; set; }
        public bool Fatec { get; set; }
        public bool Etec { get; set; }
        public EStatusAcademico SituacaoAcademica { get; set; }
    }

    public enum EStatusAcademico
    {
        Formado = 0,
        Cursando = 1
    }
}
