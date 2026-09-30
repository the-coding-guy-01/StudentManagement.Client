namespace StudentManagement.Client.Models.StudentPortal
{
    public class StudentProfile
    {
        public int Id { get; set; }

        public string AdmissionNumber { get; set; }
            = string.Empty;

        public string FirstName { get; set; }
            = string.Empty;

        public string LastName { get; set; }
            = string.Empty;

        public string FullName { get; set; }
            = string.Empty;

        public string Email { get; set; }
            = string.Empty;

        public string Phone { get; set; }
            = string.Empty;

        public DateTime? DateOfBirth { get; set; }

        public string Gender { get; set; }
            = string.Empty;

        public DateTime EnrollmentDate { get; set; }

        public bool IsActive { get; set; }

        public List<StudentProfileCourse> Courses { get; set; }
            = new List<StudentProfileCourse>();

        public string? ProfileImageUrl { get; set; }
    }

    public class StudentProfileCourse
    {
        public int CourseId { get; set; }

        public string CourseCode { get; set; }
            = string.Empty;

        public string CourseName { get; set; }
            = string.Empty;

        public string? Description { get; set; }

        public int Credits { get; set; }

        public int Duration { get; set; }

        public string? TeacherName { get; set; }
    }
}