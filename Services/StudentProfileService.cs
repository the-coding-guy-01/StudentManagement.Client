using Microsoft.AspNetCore.Components.Forms;
using StudentManagement.Client.Models.StudentPortal;
using StudentManagement.Client.Services.Interfaces;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace StudentManagement.Client.Services
{
    public class StudentProfileService
        : IStudentProfileService
    {
        private readonly HttpClient _httpClient;


        public StudentProfileService(
            HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<StudentProfile?>
            GetProfileAsync()
        {
            return await _httpClient
                .GetFromJsonAsync<StudentProfile>(
                    "api/student/profile");
        }


        public async Task<StudentProfile?>
            UpdateProfileAsync(
                UpdateStudentProfileRequest request)
        {
            var response =
                await _httpClient.PutAsJsonAsync(
                    "api/student/profile",
                    request);


            if (!response.IsSuccessStatusCode)
            {
                return null;
            }


            return await response.Content
                .ReadFromJsonAsync<StudentProfile>();
        }


        public async Task<StudentProfile?>
            UploadProfileImageAsync(
                IBrowserFile file)
        {
            const long maxFileSize =
                5 * 1024 * 1024;


            using var content =
                new MultipartFormDataContent();


            using var stream =
                file.OpenReadStream(
                    maxFileSize);


            using var fileContent =
                new StreamContent(stream);


            fileContent.Headers.ContentType =
                new MediaTypeHeaderValue(
                    file.ContentType);


            content.Add(
                fileContent,
                "file",
                file.Name);


            var response =
                await _httpClient.PostAsync(
                    "api/student/profile/photo",
                    content);


            if (!response.IsSuccessStatusCode)
            {
                return null;
            }


            return await response.Content
                .ReadFromJsonAsync<StudentProfile>();
        }


        public async Task<bool>
            RemoveProfileImageAsync()
        {
            var response =
                await _httpClient.DeleteAsync(
                    "api/student/profile/photo");


            return response.IsSuccessStatusCode;
        }

        public string GetProfileImageUrl(string? imagePath)
        {
            if (string.IsNullOrWhiteSpace(imagePath))
            {
                return string.Empty;
            }

            return new Uri(
                _httpClient.BaseAddress!,
                imagePath
            ).ToString();
        }
    }
}