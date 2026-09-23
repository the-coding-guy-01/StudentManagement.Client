using StudentManagement.Client.Models.Dashboard;

namespace StudentManagement.Client.Services.Interfaces
{
    public interface IDashboardService
    {
        Task<DashboardDto?> GetDashboardAsync();
    }
}