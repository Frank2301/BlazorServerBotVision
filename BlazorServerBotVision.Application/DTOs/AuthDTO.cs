using System.ComponentModel.DataAnnotations;

namespace BlazorServerBotVision.Application.DTOs;

public class RegisterDTO : BaseDTO
{
    [Required(ErrorMessage = "Der Vorname ist erforderlich.")]
    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Der Nachname ist erforderlich.")]
    public string LastName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Die E-Mail ist erforderlich.")]
    [EmailAddress(ErrorMessage = "Bitte eine gültige E-Mail-Adresse angeben.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Der Benutzername ist erforderlich.")]
    public string UserName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Das Passwort ist erforderlich.")]
    [MinLength(6, ErrorMessage = "Das Passwort muss mindestens 6 Zeichen lang sein.")]
    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessage = "Die Passwortbestätigung ist erforderlich.")]
    [Compare("Password", ErrorMessage = "Die Passwörter stimmen nicht überein.")]
    public string ConfirmPassword { get; set; } = string.Empty;
}

public class LoginDTO
{
    [Required(ErrorMessage = "Bitte eine E-Mail-Adresse eingeben.")]
    [EmailAddress(ErrorMessage = "Ungültige E-Mail-Adresse.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Bitte ein Passwort eingeben.")]
    [MinLength(6, ErrorMessage = "Das Passwort muss mindestens 6 Zeichen lang sein.")]
    public string Password { get; set; } = string.Empty;
}
