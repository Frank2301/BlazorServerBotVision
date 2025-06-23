using BlazorServerBotVision.Application.DTOs;
using BlazorServerBotVision.Application.Interfaces;
using BlazorServerBotVision.Domain.Entities;
using BlazorServerBotVision.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUserRepository _userRepository;
    private readonly PasswordHasher<User> _passwordHasher;
    private readonly IAuthenticationStateHandler _authStateHandler;

    public AuthenticationService(
        IUserRepository userRepository,
        IAuthenticationStateHandler authStateHandler)
    {
        _userRepository = userRepository;
        _passwordHasher = new PasswordHasher<User>();
        _authStateHandler = authStateHandler;
    }

    public async Task<UserDTO> RegisterAsync(RegisterDTO registerDto)
    {
        var existingUser = await _userRepository.FindByEmailAsync(registerDto.Email);
        if (existingUser is not null)
            throw new InvalidOperationException(
                "Ein Benutzer mit dieser E-Mail existiert bereits.");

        if (registerDto.Password != registerDto.ConfirmPassword)
            throw new InvalidOperationException(
                "Passwörter stimmen nicht überein.");

        var newUser = new User
        {
            FirstName = registerDto.FirstName,
            LastName = registerDto.LastName,
            Email = registerDto.Email,
            UserName = registerDto.UserName,
            CreatedAt = DateTime.UtcNow
        };

        newUser.PasswordHash =
            _passwordHasher.HashPassword(newUser, registerDto.Password);

        await _userRepository.AddAsync(newUser);
        await _authStateHandler.MarkUserAsAuthenticated(newUser.Email);

        return new UserDTO
        {
            Id = newUser.Id,
            FirstName = newUser.FirstName,
            LastName = newUser.LastName,
            Email = newUser.Email,
            CreatedAt = newUser.CreatedAt
        };
    }

    public async Task<UserDTO> LoginAsync(LoginDTO loginDto)
    {
        var user = await _userRepository.FindByEmailAsync(loginDto.Email);
        if (user is null)
            throw new UnauthorizedAccessException("Ungültige Anmeldedaten.");

        var result = _passwordHasher.VerifyHashedPassword(
            user, user.PasswordHash, loginDto.Password);

        if (result == PasswordVerificationResult.Failed)
            throw new UnauthorizedAccessException("Ungültige Anmeldedaten.");

        await _authStateHandler.MarkUserAsAuthenticated(user.Email);

        return new UserDTO
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            CreatedAt = user.CreatedAt
        };
    }

    public Task LogoutAsync()
        => _authStateHandler.MarkUserAsLoggedOut();
}
