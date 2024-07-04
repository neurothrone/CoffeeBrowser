using System.Security.Claims;
using CoffeeBrowser.Library.Auth;
using Microsoft.AspNetCore.Components.Authorization;

namespace CoffeeBrowser.Maui.Auth;

public class CustomAuthStateProvider : AuthenticationStateProvider, ICustomAuthStateProvider
{
    private ClaimsPrincipal _currentUser = new(new ClaimsIdentity());

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
        /*
            Provide OpenID/MSAL code to authenticate the user. See your identity
            provider's documentation for details.

            Return a new ClaimsPrincipal based on a new ClaimsIdentity.
        */
        // var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity());

        Claim[] claims =
        [
            new Claim(ClaimTypes.Name, "Zane"),
            new Claim(ClaimTypes.Role, "admin")
        ];
        var identity = new ClaimsIdentity(claims, "Custom");
        var authenticatedUser = new ClaimsPrincipal(identity);

        return Task.FromResult(authenticatedUser);
    }

    public void Logout()
    {
        _currentUser = new ClaimsPrincipal(new ClaimsIdentity());
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_currentUser)));
    }
}