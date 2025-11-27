namespace Kaloom.SharedContracts.Events
{
    public sealed record UserCreatedEvent(
        int UserId, 
        string Email,
        string GivenName,
        string FamilyName,
        string? Picture
    );
}
