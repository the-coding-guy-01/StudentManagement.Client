using System.Net;
using System.Net.Http.Json;
using StudentManagement.Client.Models.StudentPortal;
using StudentManagement.Client.Services.Interfaces;

namespace StudentManagement.Client.Services;

public class StudentResultsService(HttpClient http) : IStudentResultsService
{
    public async Task<List<AcademicResultDto>> GetResultsAsync(string? search = null, string? course = null, string? type = null, string? status = null)
    {
        var query = new List<string>();
        Add("search", search); Add("course", course); Add("assessmentType", type); Add("status", status);
        var url = "api/student/results" + (query.Count == 0 ? "" : "?" + string.Join("&", query));
        var response = await http.GetAsync(url); response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<List<AcademicResultDto>>() ?? new();
        void Add(string key, string? value) { if (!string.IsNullOrWhiteSpace(value)) query.Add($"{key}={Uri.EscapeDataString(value)}"); }
    }

    public async Task<ResultsSummaryDto> GetSummaryAsync()
    {
        var response = await http.GetAsync("api/student/results/summary"); response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<ResultsSummaryDto>() ?? new();
    }

    public async Task<AcademicResultDto?> GetResultAsync(int id)
    {
        var response = await http.GetAsync($"api/student/results/{id}");
        if (response.StatusCode == HttpStatusCode.NotFound) return null;
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<AcademicResultDto>();
    }

    public async Task<bool> CreateResultAsync(UpsertAcademicResultDto dto)
    {
        var response = await http.PostAsJsonAsync(
            "api/admin/results",
            dto);

        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateResultAsync(
        int id,
        UpsertAcademicResultDto dto)
    {
        var response = await http.PutAsJsonAsync(
            $"api/admin/results/{id}",
            dto);

        return response.IsSuccessStatusCode;
    }
}
