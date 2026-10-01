using System.ComponentModel.DataAnnotations;
namespace StudentManagement.Client.Models.AppUsers
{
    public class CreateUserRequest
    {
        [Required] public string Role { get; set; } = "Student";
        [Required, MaxLength(100)] public string FirstName { get; set; } = string.Empty;
        [Required, MaxLength(100)] public string LastName { get; set; } = string.Empty;
        [Required, EmailAddress, MaxLength(150)] public string Email { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public DateTime? EnrollmentDate { get; set; } = DateTime.Today;
        public DateTime? JoinDate { get; set; } = DateTime.Today;
        [Required, MinLength(6)] public string Password { get; set; } = string.Empty;
        [Required, Compare(nameof(Password))] public string ConfirmPassword { get; set; } = string.Empty;
    }
}
