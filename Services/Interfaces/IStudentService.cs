using StudentManagement.Client.Models.Students;

namespace StudentManagement.Client.Services.Interfaces
{
    public interface IStudentService
    {
        Task<List<StudentDto>> GetAllAsync();

        Task<StudentDto?> GetByIdAsync(int id);

        Task<StudentDto?> CreateAsync(
            CreateStudentDto dto);

        Task<int> GetTotalStudentsAsync();

        Task<StudentDto?> UpdateAsync(
            int id,
            UpdateStudentDto dto);

        Task<bool> DeleteAsync(int id);
    }
}