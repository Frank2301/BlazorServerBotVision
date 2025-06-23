namespace BlazorServerBotVision.Application.Interfaces;

using Microsoft.AspNetCore.Components.Authorization;


public interface IAuthenticationStateHandler
{
    Task<AuthenticationState> GetAuthenticationStateAsync(); 
    Task LoadUserFromSessionAsync();
    Task MarkUserAsAuthenticated(string email);
    Task MarkUserAsLoggedOut();
}
