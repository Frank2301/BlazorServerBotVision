namespace BlazorServerBotVision.Application.Interfaces;

using BlazorServerBotVision.Application.DTOs;

public interface IAuthenticationService
{
    Task<UserDTO> RegisterAsync(RegisterDTO registerDto);
    Task<UserDTO> LoginAsync(LoginDTO loginDto);
    Task LogoutAsync();
}