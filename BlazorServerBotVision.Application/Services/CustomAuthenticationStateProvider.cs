namespace BlazorServerBotVision.Application.Services;

using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using BlazorServerBotVision.Application.Interfaces;


public class CustomAuthenticationStateProvider : AuthenticationStateProvider, IAuthenticationStateHandler
{  
    private ClaimsPrincipal _currentUser = new ClaimsPrincipal(new ClaimsIdentity());
    private readonly ISessionStorageService _sessionStorage;

    public CustomAuthenticationStateProvider(ISessionStorageService sessionStorage)
    {
        _sessionStorage = sessionStorage;
    }
       
    public async Task MarkUserAsAuthenticated(string email)
    {
        var identity = new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.Name, email)
        }, "CustomAuth");

        _currentUser = new ClaimsPrincipal(identity);
        await _sessionStorage.SetItemAsync("authUser", email);
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_currentUser)));
    }
   
    public async Task MarkUserAsLoggedOut()
    {
        _currentUser = new ClaimsPrincipal(new ClaimsIdentity());
        await _sessionStorage.RemoveItemAsync("authUser");
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_currentUser)));
    }
  
    public async Task LoadUserFromSessionAsync()
    {
        var storedUser = await _sessionStorage.GetItemAsync<string>("authUser");
        if (!string.IsNullOrEmpty(storedUser))
        {
            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, storedUser)
            }, "CustomAuth");

            _currentUser = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_currentUser)));
        }
    }
  
    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        return Task.FromResult(new AuthenticationState(_currentUser));
    }
}
