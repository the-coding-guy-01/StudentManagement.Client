using StudentManagement.Client.Models.AppUsers;

namespace StudentManagement.Client.Services.Interfaces
{
    public interface IAppUserService
    {
        Task<bool> CreateUserAsync(CreateUserRequest request);

        Task<bool> RegisterStudentAsync(
            RegisterStudentUserRequest request);

        Task<List<int>> GetRegisteredStudentIdsAsync();
    }
}
