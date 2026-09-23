using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Client.Models.Teachers
{
    public class UpdateTeacherDto
    {
        [Required(ErrorMessage = "First name is required")]
        [MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;


        [Required(ErrorMessage = "Last name is required")]
        [MaxLength(100)]
        public string LastName { get; set; } = string.Empty;


        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Enter a valid email address")]
        public string Email { get; set; } = string.Empty;


        public DateTime? DateOfBirth { get; set; }


        [Required(ErrorMessage = "Gender is required")]
        [MaxLength(20)]
        public string Gender { get; set; } = string.Empty;


        [Required(ErrorMessage = "Phone number is required")]
        [MaxLength(20)]
        public string Phone { get; set; } = string.Empty;


        [Required(ErrorMessage = "Join date is required")]
        public DateTime? JoinDate { get; set; }


        public bool IsActive { get; set; }
    }
}
