namespace Kaloom.Users.Communication.DTOs.Responses
{
    public sealed record StudentResponse
    {
        public int Id { get; init; }
        public string Nome { get; init; }
        public string NomeUsuario { get; init; }
        public string FotoPerfil { get; init; }
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
            string NomeUsuario,
            string FotoPerfil,
            DateOnly DataNascimento,
            DateTime? DataCadastro,
            int IdUsuario,
            int IdTipoAluno
        )
        {
            this.Id = Id;
            this.Nome = Nome;
            this.NomeUsuario = NomeUsuario;
            this.FotoPerfil = FotoPerfil;
            this.DataNascimento = DataNascimento;
            this.DataCadastro = DataCadastro;
            this.IdUsuario = IdUsuario;
            this.IdTipoAluno = IdTipoAluno;
        }
    }
    
}
