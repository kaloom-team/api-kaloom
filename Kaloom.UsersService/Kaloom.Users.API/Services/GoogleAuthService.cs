using Google.Apis.Auth;
using Google.Apis.Auth.OAuth2.Responses;
using Kaloom.Users.Application.Services;
using Kaloom.Users.Communication.DTOs.Responses;
using System.Text.Json;

namespace Kaloom.Users.API.Services
{
    public class GoogleAuthService : IGoogleAuthService
    {
        private readonly IConfiguration _config;
        private readonly HttpClient _httpClient;

        public GoogleAuthService(IConfiguration config, HttpClient httpClient)
        {
            this._config = config;
            this._httpClient = httpClient;
        }
        public async Task<ExternalAuthData> ValidateAsync(string code)
        {
            var clientId = this._config["GoogleAuth:ClientId"] 
                ?? throw new Exception("Google ClientId ausente");

            var clientSecret = this._config["GoogleAuth:ClientSecret"] 
                ?? throw new Exception("Google ClientSecret ausente");

            var redirectUri = this._config["GoogleAuth:RedirectUri"] 
                ?? throw new Exception("Google RedirectUri ausente");

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("code", code),
                new KeyValuePair<string, string>("client_id", clientId),
                new KeyValuePair<string, string>("client_secret", clientSecret),
                new KeyValuePair<string, string>("redirect_uri", redirectUri),
                new KeyValuePair<string, string>("grant_type", "authorization_code")
            });

            var response = await this._httpClient.PostAsync("https://oauth2.googleapis.com/token", content);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var doc = JsonDocument.Parse(json);

            var idToken = doc.RootElement.GetProperty("id_token").GetString()
                ?? throw new Exception("Não foi possível obter o id_token do Google.");

            var settings = new GoogleJsonWebSignature.ValidationSettings
            {
                Audience = new[] { clientId }
            };

            var payload = await GoogleJsonWebSignature.ValidateAsync(idToken, settings);
            
            return new ExternalAuthData
            {
                Email = payload.Email,
                GivenName = payload.GivenName,
                FamilyName = payload.FamilyName,
                Name = payload.Name,
                ExternalId = payload.Subject,
                Picture = payload.Picture
            };
        }
    }
}
