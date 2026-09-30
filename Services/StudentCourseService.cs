using System.Net;
using System.Net.Http.Json;
using StudentManagement.Client.Models.StudentPortal;
using StudentManagement.Client.Services.Interfaces;

namespace StudentManagement.Client.Services
{
    public class StudentCourseService
        : IStudentCourseService
    {
        private readonly HttpClient _httpClient;

        public StudentCourseService(
            HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<MyCourseDto>>
            GetMyCoursesAsync()
        {
            var response =
                await _httpClient.GetAsync(
                    "api/student/courses");

            if (response.StatusCode ==
                HttpStatusCode.NotFound)
            {
                return new List<MyCourseDto>();
            }

            response.EnsureSuccessStatusCode();

            return await response.Content
                .ReadFromJsonAsync<List<MyCourseDto>>()
                ?? new List<MyCourseDto>();
        }
    }
}