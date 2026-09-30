namespace StudentManagement.Client.Models.AppUsers
{
    public class RegisterStudentUserRequest
    {
        public int StudentId { get; set; }

        public string Password { get; set; } = string.Empty;

        public string ConfirmPassword { get; set; } = string.Empty;
    }
}