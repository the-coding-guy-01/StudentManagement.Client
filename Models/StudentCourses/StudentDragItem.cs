using StudentManagement.Client.Models.Students;

namespace StudentManagement.Client.Models.StudentCourses
{
    public class StudentDragItem
    {
        public StudentDto Student { get; set; } = new();

        public int? CourseId { get; set; }

        public string ZoneIdentifier { get; set; } = "unassigned";
    }
}