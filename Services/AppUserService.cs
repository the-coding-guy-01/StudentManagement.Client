using System.Net.Http.Json;
using StudentManagement.Client.Models.AppUsers;
using StudentManagement.Client.Services.Interfaces;

namespace StudentManagement.Client.Services
{
    public class AppUserService : IAppUserService
    {
        private readonly HttpClient _httpClient;

        public AppUserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateUserAsync(CreateUserRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("api/AppUsers", request);
            return response.IsSuccessStatusCode;
        }


        public async Task<bool> RegisterStudentAsync(
            RegisterStudentUserRequest request)
        {
            var response =
                await _httpClient.PostAsJsonAsync(
                    "api/AppUsers/register-student",
                    request);


            return response.IsSuccessStatusCode;
        }

        public async Task<List<int>> GetRegisteredStudentIdsAsync()
        {
            return await _httpClient
                .GetFromJsonAsync<List<int>>(
                    "api/AppUsers/registered-student-ids")
                ?? new List<int>();
        }
    }
}
