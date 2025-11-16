namespace Kaloom.Communication.DTOs.Responses
{
    public sealed record EtecResponse : IInstitutionResponse
    {
        public int Id { get; init; }
        public string NomeUnidade { get; init; }
        public EtecResponse(int Id, string NomeUnidade)
        {
            this.Id = Id;
            this.NomeUnidade = NomeUnidade;
        }

        public EtecResponse()
        {
        }
    }
}
