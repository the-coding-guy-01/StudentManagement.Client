using System.Net.Http.Json;
using StudentManagement.Client.Models.Dashboard;
using StudentManagement.Client.Services.Interfaces;

namespace StudentManagement.Client.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly HttpClient _httpClient;

        public DashboardService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<DashboardDto?> GetDashboardAsync()
        {
            return await _httpClient
                .GetFromJsonAsync<DashboardDto>("api/dashboard");
        }
    }
}