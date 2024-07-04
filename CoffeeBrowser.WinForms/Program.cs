using CoffeeBrowser.Library.Services;
using CoffeeBrowser.WinForms.Auth;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace CoffeeBrowser.WinForms;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        var services = new ServiceCollection();
        services.AddWindowsFormsBlazorWebView();

#if DEBUG
        services.AddBlazorWebViewDeveloperTools();
#endif

        services.AddAuthorizationCore();
        services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

        services.AddTransient<ICoffeeService, CoffeeService>();

        var serviceProvider = services.BuildServiceProvider();

        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        // Application.Run(new MainForm());
        Application.Run(new MainForm(serviceProvider));
    }
}