using StudentManagement.Client.Models.Courses;
using StudentManagement.Client.Services.Interfaces;
using System.Net.Http;
using System.Net.Http.Json;

namespace StudentManagement.Client.Services
{
    public class CourseService : ICourseService
    {
        private readonly HttpClient _http;

        public CourseService(HttpClient http)
        {
            _http = http;
        }   

        public async Task<List<CourseDto>> GetAllAsync()
        {
            var courses = await _http.GetFromJsonAsync<List<CourseDto>>("api/courses");
            return courses ?? new List<CourseDto>();
        }

        public async Task<CourseDto?> GetByIdAsync(int id)
        {
            var response = await _http.GetAsync($"api/courses/{id}");
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CourseDto>();
        }

        public async Task<CourseDto> CreateAsync(CreateCourseDto dto)
        {
            var response = await _http.PostAsJsonAsync("api/courses", dto);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CourseDto>() ?? throw new Exception("Failed to create course.");
        }

        public async Task<bool> UpdateAsync(int id, UpdateCourseDto dto)
        {
            var response = await _http.PutAsJsonAsync($"api/courses/{id}", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _http.DeleteAsync($"api/courses/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<CourseDto?> AssignTeacherAsync(
        int courseId,
        int teacherId)
        {
            var response = await _http.PutAsync(
                $"api/courses/{courseId}/teacher/{teacherId}",
                null);

            if (response.StatusCode ==
                System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();

            return await response.Content
                .ReadFromJsonAsync<CourseDto>();
        }


        public async Task<bool> RemoveTeacherAsync(
            int courseId)
        {
            var response = await _http.DeleteAsync(
                $"api/courses/{courseId}/teacher");

            if (response.StatusCode ==
                System.Net.HttpStatusCode.NotFound)
            {
                return false;
            }

            response.EnsureSuccessStatusCode();

            return true;
        }
    }

}
