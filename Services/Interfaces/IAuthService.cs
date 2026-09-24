using StudentManagement.Client.Models.Auth;

namespace StudentManagement.Client.Services.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponse?> LoginAsync(
            LoginRequest request);

        Task LogoutAsync();
    }
}