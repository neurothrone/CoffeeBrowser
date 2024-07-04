﻿using CoffeeBrowser.Library.Services;
using CoffeeBrowser.Maui.Auth;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Logging;

namespace CoffeeBrowser.Maui;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts => { fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular"); });

        builder.Services.AddMauiBlazorWebView();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        builder.Services.AddAuthorizationCore();
        // !: Not necessary anymore after using <AuthorizeRouteView/>
        // builder.Services.AddCascadingAuthenticationState(); // Equivalent to <CascadingAuthenticationState></...>
        builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

        builder.Services.AddTransient<ICoffeeService, CoffeeService>();

        return builder.Build();
    }
}