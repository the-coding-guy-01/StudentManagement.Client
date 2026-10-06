namespace StudentManagement.Client.Models.StudentPortal
{
    public class UpsertAcademicResultDto
    {
        public int studentId { get; set; }
        public int courseId { get; set; }
        public string AssessmentName { get; set; } = string.Empty;
        public string AssessmentType { get; set; } = string.Empty;
        public decimal? MarksObtained { get; set; }
        public decimal MaximumMarks { get; set; }
        public decimal PassMark { get; set; }
        public string Grade { get; set; } 
        public bool isPublished { get; set; }
    }
}
