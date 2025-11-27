using Kaloom.Users.Communication.DTOs.Responses;

namespace Kaloom.Users.Application.Services
{
    public interface IGithubAuthService
    {
        public Task<ExternalAuthData> ValidateAsync(string code);
    }
}
