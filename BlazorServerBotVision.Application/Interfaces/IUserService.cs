namespace BlazorServerBotVision.Application.Interfaces;

using BlazorServerBotVision.Application.DTOs;


public interface IUserService
{
    Task<UserDTO> GetUserByIdAsync(Guid id);
    Task<IEnumerable<UserDTO>> GetAllUsersAsync();
    Task AddUserAsync(UserDTO userDto);
    Task UpdateUserAsync(UserDTO userDto);
    Task DeleteUserAsync(Guid id);
    Task<UserDTO> GetOrCreateDefaultUserAsync();

    Task<UserDTO> GetUserByEmailAsync(string email); 
}