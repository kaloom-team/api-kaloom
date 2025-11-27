namespace Kaloom.Students.Communication.DTOs.Responses
{
    public sealed record FatecResponse : IInstitutionResponse
    {
        public int Id { get; init; }
        public string NomeUnidade { get; init; }
        public FatecResponse(int Id, string NomeUnidade)
        {
            this.Id = Id;
            this.NomeUnidade = NomeUnidade;
        }

        public FatecResponse()
        {
        }
    }
    
}
