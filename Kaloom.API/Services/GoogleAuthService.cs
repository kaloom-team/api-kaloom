using Google.Apis.Auth;
using Google.Apis.Auth.OAuth2.Responses;
using Kaloom.Application.Services;
using Kaloom.Communication.DTOs.Responses;
using System.Text.Json;

namespace Kaloom.API.Services
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
            var clientId = _config["GoogleAuth:ClientId"];
            var clientSecret = _config["GoogleAuth:ClientSecret"];
            var redirectUri = _config["GoogleAuth:RedirectUri"];

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
