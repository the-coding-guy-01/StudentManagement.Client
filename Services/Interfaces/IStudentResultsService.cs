using StudentManagement.Client.Models.StudentPortal;

namespace StudentManagement.Client.Services.Interfaces;

public interface IStudentResultsService
{
    Task<List<AcademicResultDto>> GetResultsAsync(string? search = null, string? course = null, string? type = null, string? status = null);
    Task<ResultsSummaryDto> GetSummaryAsync();
    Task<AcademicResultDto?> GetResultAsync(int id);
    Task<bool> CreateResultAsync(UpsertAcademicResultDto dto);
    Task<bool> UpdateResultAsync(int id, UpsertAcademicResultDto dto);
}
