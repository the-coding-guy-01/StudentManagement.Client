using StudentManagement.Client.Models.StudentPortal;

namespace StudentManagement.Client.Services.Interfaces
{
    public interface IStudentCourseService
    {
        Task<MyCourseDto?> GetMyCourseAsync();
    }
}