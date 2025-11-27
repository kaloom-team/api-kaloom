namespace Kaloom.Users.Communication.DTOs.Responses
{
    public sealed record ExternalAuthData
    {
        public string Email { get; init; }
        public string GivenName { get; init; }
        public string FamilyName { get; init; }
        public string Name { get; init; }
        public string Picture { get; init; }
        public string ExternalId { get; init; }
        public ExternalAuthData(
            string email,
            string name,
            string externalId,
            string givenName,
            string familyName,
            string picture
        )
        {
            this.Email = email;
            this.Name = name;
            this.ExternalId = externalId;
            this.GivenName = givenName;
            this.FamilyName = familyName;
            this.Picture = picture;
        }
        public ExternalAuthData()
        {
        }
    }
}
