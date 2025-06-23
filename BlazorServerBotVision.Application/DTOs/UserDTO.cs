namespace BlazorServerBotVision.Application.DTOs;

public class UserDTO : BaseDTO
{
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
}