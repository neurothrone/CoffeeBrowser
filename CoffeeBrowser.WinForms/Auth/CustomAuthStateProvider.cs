using System.Security.Claims;
using System.Security.Principal;
using Microsoft.AspNetCore.Components.Authorization;
using CoffeeBrowser.Library.Auth;

namespace CoffeeBrowser.WinForms.Auth;

public class CustomAuthStateProvider : AuthenticationStateProvider, ICustomAuthStateProvider
{
    private ClaimsPrincipal _currentUser = GetWindowsPrincipal();

    public override Task<AuthenticationState> GetAuthenticationStateAsync() =>
        Task.FromResult(new AuthenticationState(_currentUser));

    public Task LogInAsync()
    {
        var loginTask = LogInAsyncCore();
        NotifyAuthenticationStateChanged(loginTask);

        return loginTask;

        async Task<AuthenticationState> LogInAsyncCore()
        {
            var user = await LoginWithExternalProviderAsync();
            _currentUser = user;

            return new AuthenticationState(_currentUser);
        }
    }

    private Task<ClaimsPrincipal> LoginWithExternalProviderAsync()
    {
        ClaimsPrincipal authenticatedUser = GetWindowsPrincipal();
        return Task.FromResult(authenticatedUser);
    }

    private static ClaimsPrincipal GetWindowsPrincipal()
    {
        var identity = WindowsIdentity.GetCurrent();
        return new WindowsPrincipal(identity);
    }

    public void Logout()
    {
        _currentUser = new ClaimsPrincipal(new ClaimsIdentity());
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_currentUser)));
    }
}