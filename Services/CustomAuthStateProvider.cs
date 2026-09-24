using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using StudentManagement.Client.Models.Auth;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace StudentManagement.Client.Services
{
    public class CustomAuthStateProvider
        : AuthenticationStateProvider
    {
        private readonly IJSRuntime _jsRuntime;
        private readonly HttpClient _httpClient;


        private readonly ClaimsPrincipal _anonymous =
            new(
                new ClaimsIdentity());


        public CustomAuthStateProvider(
            IJSRuntime jsRuntime,
            HttpClient httpClient)
        {
            _jsRuntime = jsRuntime;
            _httpClient = httpClient;
        }


        public override async
            Task<AuthenticationState>
            GetAuthenticationStateAsync()
        {
            var token =
                await _jsRuntime.InvokeAsync<string?>(
                    "sessionStorage.getItem",
                    "authToken");


            var username =
                await _jsRuntime.InvokeAsync<string?>(
                    "sessionStorage.getItem",
                    "authUsername");


            var role =
                await _jsRuntime.InvokeAsync<string?>(
                    "sessionStorage.getItem",
                    "authRole");


            var userId =
                await _jsRuntime.InvokeAsync<string?>(
                    "sessionStorage.getItem",
                    "authUserId");


            var expiry =
                await _jsRuntime.InvokeAsync<string?>(
                    "sessionStorage.getItem",
                    "authExpiry");


            if (string.IsNullOrWhiteSpace(token) ||
                string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(role))
            {
                return new AuthenticationState(
                    _anonymous);
            }


            if (DateTime.TryParse(
                    expiry,
                    out var expiresAt))
            {
                if (expiresAt.ToUniversalTime()
                    <= DateTime.UtcNow)
                {
                    await ClearAuthenticationAsync();

                    return new AuthenticationState(
                        _anonymous);
                }
            }


            _httpClient.DefaultRequestHeaders
                .Authorization =
                new AuthenticationHeaderValue(
                    "Bearer",
                    token);


            var claims =
                new List<Claim>
                {
                    new(
                        ClaimTypes.Name,
                        username),

                    new(
                        ClaimTypes.Role,
                        role),

                    new(
                        ClaimTypes.NameIdentifier,
                        userId ?? string.Empty)
                };


            var identity =
                new ClaimsIdentity(
                    claims,
                    "jwt");


            var user =
                new ClaimsPrincipal(identity);


            return new AuthenticationState(user);
        }


        public async Task
            MarkUserAsAuthenticatedAsync(
                LoginResponse response)
        {
            await _jsRuntime.InvokeVoidAsync(
                "sessionStorage.setItem",
                "authToken",
                response.Token);


            await _jsRuntime.InvokeVoidAsync(
                "sessionStorage.setItem",
                "authUsername",
                response.Username);


            await _jsRuntime.InvokeVoidAsync(
                "sessionStorage.setItem",
                "authRole",
                response.Role);


            await _jsRuntime.InvokeVoidAsync(
                "sessionStorage.setItem",
                "authUserId",
                response.UserId.ToString());


            await _jsRuntime.InvokeVoidAsync(
                "sessionStorage.setItem",
                "authExpiry",
                response.ExpiresAt.ToString("O"));


            _httpClient.DefaultRequestHeaders
                .Authorization =
                new AuthenticationHeaderValue(
                    "Bearer",
                    response.Token);


            var claims =
                new List<Claim>
                {
                    new(
                        ClaimTypes.Name,
                        response.Username),

                    new(
                        ClaimTypes.Role,
                        response.Role),

                    new(
                        ClaimTypes.NameIdentifier,
                        response.UserId.ToString())
                };


            var identity =
                new ClaimsIdentity(
                    claims,
                    "jwt");


            var user =
                new ClaimsPrincipal(identity);


            NotifyAuthenticationStateChanged(
                Task.FromResult(
                    new AuthenticationState(user)));
        }


        public async Task
            MarkUserAsLoggedOutAsync()
        {
            await ClearAuthenticationAsync();


            NotifyAuthenticationStateChanged(
                Task.FromResult(
                    new AuthenticationState(
                        _anonymous)));
        }


        private async Task
            ClearAuthenticationAsync()
        {
            await _jsRuntime.InvokeVoidAsync(
                "sessionStorage.removeItem",
                "authToken");


            await _jsRuntime.InvokeVoidAsync(
                "sessionStorage.removeItem",
                "authUsername");


            await _jsRuntime.InvokeVoidAsync(
                "sessionStorage.removeItem",
                "authRole");


            await _jsRuntime.InvokeVoidAsync(
                "sessionStorage.removeItem",
                "authUserId");


            await _jsRuntime.InvokeVoidAsync(
                "sessionStorage.removeItem",
                "authExpiry");


            _httpClient.DefaultRequestHeaders
                .Authorization = null;
        }
    }
}