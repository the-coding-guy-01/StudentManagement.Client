using StudentManagement.Client.Models.Announcements;
using StudentManagement.Client.Services.Interfaces;
using System.Net.Http.Json;

namespace StudentManagement.Client.Services
{
    public class AnnouncementService: IAnnouncementService
    {
        private readonly HttpClient _http;

        public AnnouncementService(HttpClient http)
        {
            _http = http;
        }

        public async Task<AnnouncementDto?> GetAnnouncementByIdAsync(int id)
        {
            var response = await _http.GetAsync($"api/Announcements/{id}");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<AnnouncementDto>();
        }

        public async Task<IEnumerable<AnnouncementDto>> GetAllAnnouncementsAsync()
        {
            var announcements = await _http.GetFromJsonAsync<List<AnnouncementDto>>(
                "api/Announcements"
            );

            return announcements ?? new List<AnnouncementDto>();
        }

        public async Task<AnnouncementDto?> CreateAnnouncementAsync(CreateAnnouncementDto dto)
        {
            var response = await _http.PostAsJsonAsync("api/Announcements", dto);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<AnnouncementDto>();
        }

        public async Task<AnnouncementDto?> UpdateAnnouncementAsync(int id, UpdateAnnouncementDto dto)
        {
            var response = await _http.PutAsJsonAsync($"api/Announcements/{id}", dto);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<AnnouncementDto>();
        }

        public async Task<bool> DeleteAnnouncementAsync(int id)
        {
            var response = await _http.DeleteAsync($"api/Announcements/{id}");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return false;
            }

            response.EnsureSuccessStatusCode();

            return true;
        }

    }
}
