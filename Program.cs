using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using StudentManagement.Client;
using StudentManagement.Client.Services;
using StudentManagement.Client.Services.Interfaces;

var builder =
    WebAssemblyHostBuilder.CreateDefault(args);


builder.RootComponents.Add<App>("#app");

builder.RootComponents.Add<HeadOutlet>(
    "head::after");


// MudBlazor

builder.Services.AddMudServices();

builder.Services.AddAuthorizationCore();

// API URL

var apiBaseUrl =
    builder.Configuration["ApiBaseUrl"];

if (string.IsNullOrWhiteSpace(apiBaseUrl))
{
    throw new InvalidOperationException(
        "ApiBaseUrl is not configured.");
}


// HttpClient

builder.Services.AddScoped(
    sp => new HttpClient
    {
        BaseAddress = new Uri(apiBaseUrl)
    });


// Application Services

builder.Services.AddScoped<
    IStudentService,
    StudentService>();

builder.Services.AddScoped<ICourseService, CourseService>();

builder.Services.AddScoped<ITeacherService, TeacherService>();

builder.Services.AddScoped<IDashboardService, DashboardService>();

builder.Services.AddScoped<
    CustomAuthStateProvider>();


builder.Services.AddScoped<
    AuthenticationStateProvider>(
        provider =>
            provider.GetRequiredService<
                CustomAuthStateProvider>());


builder.Services.AddScoped<
    IAuthService,
    AuthService>();

await builder.Build().RunAsync();