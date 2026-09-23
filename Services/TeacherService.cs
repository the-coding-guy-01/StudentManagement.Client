using StudentManagement.Client.Models.Teachers;
using StudentManagement.Client.Services.Interfaces;
using System.Net.Http.Json;

namespace StudentManagement.Client.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly HttpClient _httpClient;

        public TeacherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<List<TeacherDto>> GetAllAsync()
        {
            var teachers =
                await _httpClient
                    .GetFromJsonAsync<List<TeacherDto>>(
                        "api/teachers");

            return teachers ?? new List<TeacherDto>();
        }


        public async Task<TeacherDto?> GetByIdAsync(int id)
        {
            var response =
                await _httpClient.GetAsync(
                    $"api/teachers/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            return await response.Content
                .ReadFromJsonAsync<TeacherDto>();
        }


        public async Task<int> GetTotalTeachersAsync()
        {
            return await _httpClient
                .GetFromJsonAsync<int>(
                    "api/teachers/count");
        }


        public async Task<TeacherDto?> CreateAsync(
            CreateTeacherDto dto)
        {
            var response =
                await _httpClient.PostAsJsonAsync(
                    "api/teachers",
                    dto);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            return await response.Content
                .ReadFromJsonAsync<TeacherDto>();
        }


        public async Task<TeacherDto?> UpdateAsync(
            int id,
            UpdateTeacherDto dto)
        {
            var response =
                await _httpClient.PutAsJsonAsync(
                    $"api/teachers/{id}",
                    dto);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            return await response.Content
                .ReadFromJsonAsync<TeacherDto>();
        }


        public async Task<bool> DeleteAsync(int id)
        {
            var response =
                await _httpClient.DeleteAsync(
                    $"api/teachers/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}