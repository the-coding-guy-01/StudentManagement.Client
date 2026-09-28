using Microsoft.AspNetCore.Components.Forms;
using StudentManagement.Client.Models.StudentPortal;

namespace StudentManagement.Client.Services.Interfaces
{
    public interface IStudentProfileService
    {
        Task<StudentProfile?>
            GetProfileAsync();

        Task<StudentProfile?>
            UpdateProfileAsync(
                UpdateStudentProfileRequest request);

        Task<StudentProfile?>
            UploadProfileImageAsync(
                IBrowserFile file);

        Task<bool>
            RemoveProfileImageAsync();
    }
}