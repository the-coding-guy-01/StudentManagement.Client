using System.Net.Http.Json;
using StudentManagement.Client.Models.Auth;
using StudentManagement.Client.Services.Interfaces;

namespace StudentManagement.Client.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;

        private readonly CustomAuthStateProvider
            _authStateProvider;


        public AuthService(
            HttpClient httpClient,
            CustomAuthStateProvider authStateProvider)
        {
            _httpClient = httpClient;
            _authStateProvider = authStateProvider;
        }


        public async Task<LoginResponse?>
            LoginAsync(LoginRequest request)
        {
            var response =
                await _httpClient.PostAsJsonAsync(
                    "api/auth/login",
                    request);


            if (!response.IsSuccessStatusCode)
            {
                return null;
            }


            var result =
                await response.Content
                    .ReadFromJsonAsync<LoginResponse>();


            if (result == null)
            {
                return null;
            }


            await _authStateProvider
                .MarkUserAsAuthenticatedAsync(
                    result);


            return result;
        }


        public async Task LogoutAsync()
        {
            await _authStateProvider
                .MarkUserAsLoggedOutAsync();
        }
    }
}