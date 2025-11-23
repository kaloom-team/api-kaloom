namespace Kaloom.Communication.DTOs.Responses
{
    public sealed record UserResponse
    {
        public int Id { get; init; }
        public string Email { get; init; }
        public UserResponse
        (
            int Id,
            string Email
        )
        {
            this.Id = Id;
            this.Email = Email;
        }
        public UserResponse()
        {
        }
    }
}