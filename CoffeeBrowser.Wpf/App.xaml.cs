using System.Windows;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using CoffeeBrowser.Library.Services;
using CoffeeBrowser.Wpf.Auth;

namespace CoffeeBrowser.Wpf;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private void App_OnStartup(object sender, StartupEventArgs e)
    {
        var services = new ServiceCollection();
        services.AddWpfBlazorWebView();

#if DEBUG
        services.AddBlazorWebViewDeveloperTools();
#endif

        services.AddAuthorizationCore();
        services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
        services.AddTransient<ICoffeeService, CoffeeService>();

        var serviceProvider = services.BuildServiceProvider();
        this.Resources.Add("ServiceProvider", serviceProvider);
    }
}