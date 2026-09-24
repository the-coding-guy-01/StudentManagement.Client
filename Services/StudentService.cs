using StudentManagement.Client.Models.Students;
using StudentManagement.Client.Services.Interfaces;
using System.Net.Http;
using System.Net.Http.Json;

namespace StudentManagement.Client.Services
{
    public class StudentService : IStudentService
    {
        private readonly HttpClient _http;

        public StudentService(HttpClient http)
        {
            _http = http;
        }


        public async Task<List<StudentDto>> GetAllAsync()
        {
            var students =
                await _http.GetFromJsonAsync<List<StudentDto>>(
                    "api/students");

            return students ?? new List<StudentDto>();
        }


        public async Task<StudentDto?> GetByIdAsync(int id)
        {
            var response =
                await _http.GetAsync($"api/students/{id}");

            if (response.StatusCode ==
                System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();

            return await response.Content
                .ReadFromJsonAsync<StudentDto>();
        }

        public async Task<int> GetTotalStudentsAsync()
        {
            return await _http.GetFromJsonAsync<int>("api/students/count");
        }


        public async Task<StudentDto?> CreateAsync(
            CreateStudentDto dto)
        {
            var response =
                await _http.PostAsJsonAsync(
                    "api/students",
                    dto);

            response.EnsureSuccessStatusCode();

            return await response.Content
                .ReadFromJsonAsync<StudentDto>();
        }


        public async Task<StudentDto?> UpdateAsync(
            int id,
            UpdateStudentDto dto)
        {
            var response =
                await _http.PutAsJsonAsync(
                    $"api/students/{id}",
                    dto);

            if (response.StatusCode ==
                System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();

            return await response.Content
                .ReadFromJsonAsync<StudentDto>();
        }


        public async Task<bool> DeleteAsync(int id)
        {
            var response =
                await _http.DeleteAsync(
                    $"api/students/{id}");

            if (response.StatusCode ==
                System.Net.HttpStatusCode.NotFound)
            {
                return false;
            }

            response.EnsureSuccessStatusCode();

            return true;
        }

        public async Task<StudentDto?> AssignCourseAsync(
    int studentId,
    int courseId)
        {
            var response = await _http.PutAsync(
                $"api/students/{studentId}/course/{courseId}",
                null);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            return await response.Content
                .ReadFromJsonAsync<StudentDto>();
        }

        public async Task<bool> RemoveCourseAsync(
    int studentId)
        {
            var response = await _http.DeleteAsync(
                $"api/students/{studentId}/course");

            return response.IsSuccessStatusCode;
        }
    }
}