namespace Kaloom.Communication.DTOs.Requests
{
    public class EtecRequest : IInstitutionRequest
    {
        public int Id { get; set; }
        public string NomeUnidade { get; set; } = string.Empty;
    }
}
