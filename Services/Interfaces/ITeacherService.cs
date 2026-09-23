using StudentManagement.Client.Models.Teachers;

namespace StudentManagement.Client.Services.Interfaces
{
    public interface ITeacherService
    {
        Task<List<TeacherDto>> GetAllAsync();

        Task<TeacherDto?> GetByIdAsync(int id);

        Task<int> GetTotalTeachersAsync();

        Task<TeacherDto?> CreateAsync(CreateTeacherDto dto);

        Task<TeacherDto?> UpdateAsync(
            int id,
            UpdateTeacherDto dto);

        Task<bool> DeleteAsync(int id);
    }
}