using Microsoft.AspNetCore.Components.Authorization;
using MiParte.Models;
using System.Security.Claims;
using System.Threading.Tasks;

public class AuthenticationStateProviderService : AuthenticationStateProvider
{
    private Usuario _currentUser;

    public void MarkUserAsAuthenticated(Usuario user)
    {
        _currentUser = user;
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    public void MarkUserAsLoggedOut()
    {
        _currentUser = null;
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var identity = _currentUser != null
            ? new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, _currentUser.Username),
                new Claim(ClaimTypes.Role, _currentUser.IsAdmin ? "Admin" : "User")
            }, "apiauth")
            : new ClaimsIdentity();

        return Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity)));
    }
}
