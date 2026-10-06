namespace StudentManagement.Client.Models.StudentPortal;

public class AcademicResultDto
{
    public int Id { get; set; }
    public string CourseName { get; set; } = string.Empty;
    public string AssessmentName { get; set; } = string.Empty;
    public string AssessmentType { get; set; } = string.Empty;
    public decimal? MarksObtained { get; set; }
    public decimal MaximumMarks { get; set; }
    public decimal? Percentage { get; set; }
    public string? Grade { get; set; }
    public string Status { get; set; } = "Pending";
    public DateTime? PublishedDate { get; set; }
}

public class ResultsSummaryDto
{
    public decimal? AverageScore { get; set; }
    public decimal? HighestScore { get; set; }
    public int PassedAssessments { get; set; }
    public int TotalAssessments { get; set; }
}
