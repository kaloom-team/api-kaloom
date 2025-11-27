using Kaloom.SharedContracts.DTOs;
using Kaloom.Users.Application.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Kaloom.Users.Infrastructure.Clients
{
    public class StudentDataHttpClient : IStudentDataClient
    {
        private readonly HttpClient _httpClient;

        public StudentDataHttpClient(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<StudentResponse?> GetStudentByUserIdAsync(int userId)
        {
            var response = await _httpClient.GetAsync($"/api/Aluno/GetByReferenceId/{userId}");

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();

            var studentResponse = await response.Content.ReadFromJsonAsync<StudentResponse>();
            return studentResponse;
        }
    }
}
