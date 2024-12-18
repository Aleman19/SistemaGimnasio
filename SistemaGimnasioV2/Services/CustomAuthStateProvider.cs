using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

public class CustomAuthStateProvider : AuthenticationStateProvider
{
    private readonly ILocalStorageService _localStorage;
    private readonly ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());

    public CustomAuthStateProvider(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var username = await _localStorage.GetItemAsync<string>("username");
        var role = await _localStorage.GetItemAsync<string>("role");
        var email = await _localStorage.GetItemAsync<string>("email");
        var userId = await _localStorage.GetItemAsync<string>("userId");

        if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(role))
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, role)
            };

            if (!string.IsNullOrEmpty(email))
                claims.Add(new Claim(ClaimTypes.Email, email));

            if (!string.IsNullOrEmpty(userId))
                claims.Add(new Claim(ClaimTypes.NameIdentifier, userId));

            var identity = new ClaimsIdentity(claims, "CustomAuthentication");
            var authenticatedUser = new ClaimsPrincipal(identity);

            return new AuthenticationState(authenticatedUser);
        }

        return new AuthenticationState(_anonymous);
    }

    public async Task SetUserAsync(string username, string role, string email = "", string userId = "")
    {
        // Guardar datos en LocalStorage
        await _localStorage.SetItemAsync("username", username);
        await _localStorage.SetItemAsync("role", role);

        if (!string.IsNullOrEmpty(email))
            await _localStorage.SetItemAsync("email", email);

        if (!string.IsNullOrEmpty(userId))
            await _localStorage.SetItemAsync("userId", userId);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, role)
        };

        if (!string.IsNullOrEmpty(email))
            claims.Add(new Claim(ClaimTypes.Email, email));

        if (!string.IsNullOrEmpty(userId))
            claims.Add(new Claim(ClaimTypes.NameIdentifier, userId));

        var identity = new ClaimsIdentity(claims, "CustomAuthentication");
        var authenticatedUser = new ClaimsPrincipal(identity);

        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(authenticatedUser)));
    }

    public async Task LogoutAsync()
    {
        // Eliminar datos de LocalStorage
        await _localStorage.RemoveItemAsync("username");
        await _localStorage.RemoveItemAsync("role");
        await _localStorage.RemoveItemAsync("email");
        await _localStorage.RemoveItemAsync("userId");

        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_anonymous)));
    }
}
