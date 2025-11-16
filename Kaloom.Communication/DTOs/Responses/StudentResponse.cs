namespace Kaloom.Communication.DTOs.Responses
{
    public sealed record StudentResponse
    (
        int Id,
        string Nome,
        string NomeUsuario,
        string FotoPerfil,
        DateOnly DataNascimento,
        DateTime? DataCadastro,
        int IdUsuario,
        int IdTipoAluno
    );
}
