using Google.Apis.Auth.OAuth2.Responses;
using Kaloom.Application.Services;
using Kaloom.Communication.DTOs.Responses;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Kaloom.API.Services
{
    public class GithubAuthService : IGithubAuthService
    {
        private readonly IConfiguration _config;
        private readonly HttpClient _http;

        public GithubAuthService(IConfiguration config, HttpClient http)
        {
            this._config = config;
            this._http = http;

            if (!this._http.DefaultRequestHeaders.UserAgent.Any())
            {
                this._http.DefaultRequestHeaders.UserAgent
                    .Add(new ProductInfoHeaderValue("kaloom", "1.0"));
            }

            if (!this._http.DefaultRequestHeaders.Accept.Any())
            {
                this._http.DefaultRequestHeaders.Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
        }

        public async Task<ExternalAuthData> ValidateAsync(string code)
        {
            string token;
            var clientId = this._config["Github:ClientId"] 
                ?? throw new Exception("Github ClientId ausente");

            var clientSecret = this._config["Github:ClientSecret"] 
                ?? throw new Exception("Github ClientId ausente");

            var tokenResponse = await this._http.PostAsync(
                "https://github.com/login/oauth/access_token",
                new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "client_id", clientId },
                    { "client_secret", clientSecret },
                    { "code", code }
                })
            );

            var tokenBody = await tokenResponse.Content.ReadAsStringAsync();


            if (tokenBody.TrimStart().StartsWith("{"))
            {
                var json = JsonDocument.Parse(tokenBody).RootElement;
                token = json.GetProperty("access_token").GetString() ?? string.Empty;
            }
            else
            {
                token = System.Web.HttpUtility.ParseQueryString(tokenBody).Get("access_token") ?? string.Empty;
            }
            
            if (!tokenResponse.IsSuccessStatusCode)
                throw new Exception($"GitHub token error: {tokenBody}");


            if (string.IsNullOrWhiteSpace(token))
                throw new Exception("Não foi possível obter o token de acesso do GitHub.");

            this._http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var userRes = await this._http.GetStringAsync("https://api.github.com/user");
            var emailRes = await this._http.GetStringAsync("https://api.github.com/user/emails");

            var user = JsonDocument.Parse(userRes).RootElement;

            var emailArray = JsonDocument.Parse(emailRes).RootElement.EnumerateArray();

            var email = emailArray
                .FirstOrDefault(e => e.TryGetProperty("primary", out var p) && p.GetBoolean())
                .GetProperty("email")
                .GetString();

            if (email == null)
            {
                email = emailArray
                    .FirstOrDefault(e => e.TryGetProperty("verified", out var v) && v.GetBoolean())
                    .GetProperty("email")
                    .GetString();
            }

            if (email == null)
                throw new Exception("O GitHub não retornou nenhum e-mail válido.");

            return new ExternalAuthData
            {
                Email = email,
                Name = user.GetProperty("name").GetString() ?? string.Empty,
                GivenName = user.GetProperty("login").GetString() ?? string.Empty,
                ExternalId = user.GetProperty("id").GetInt64().ToString(),
                Picture = user.GetProperty("avatar_url").GetString() ?? string.Empty
            };
        }
    }
}
