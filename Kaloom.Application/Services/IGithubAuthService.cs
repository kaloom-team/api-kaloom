using Kaloom.Communication.DTOs.Responses;

namespace Kaloom.Application.Services
{
    public interface IGithubAuthService
    {
        public Task<ExternalAuthData> ValidateAsync(string code);
    }
}
