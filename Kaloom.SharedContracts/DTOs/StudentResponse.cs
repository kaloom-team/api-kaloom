namespace Kaloom.SharedContracts.DTOs
{
    public sealed record StudentResponse
    {
        public int Id { get; init; }
        public string Nome { get; init; }
        public string Sobrenome { get; init; }
        public DateOnly DataNascimento { get; init; }
        public DateTime? DataCadastro { get; init; }
        public int IdUsuario { get; init; }
        public int IdTipoAluno { get; init; }

        public StudentResponse() 
        { 
        }
        public StudentResponse(
            int Id,
            string Nome,
            string Sobrenome,
            DateOnly DataNascimento,
            DateTime? DataCadastro,
            int IdUsuario,
            int IdTipoAluno
        )
        {
            this.Id = Id;
            this.Nome = Nome;
            this.Sobrenome = Sobrenome;
            this.DataNascimento = DataNascimento;
            this.DataCadastro = DataCadastro;
            this.IdUsuario = IdUsuario;
            this.IdTipoAluno = IdTipoAluno;
        }
    }
    
}
