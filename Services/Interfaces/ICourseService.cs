using StudentManagement.Client.Models.Courses;

namespace StudentManagement.Client.Services.Interfaces
{
    public interface ICourseService
    {
        Task<List<CourseDto>> GetAllAsync();

        Task<CourseDto?> GetByIdAsync(int id);

        Task<CourseDto> CreateAsync(CreateCourseDto dto);

        Task<bool> UpdateAsync(int id, UpdateCourseDto dto);

        Task<bool> DeleteAsync(int id);

        // Teacher assignment
        Task<CourseDto?> AssignTeacherAsync(
            int courseId,
            int teacherId);

        Task<bool> RemoveTeacherAsync(
            int courseId);
    }
}