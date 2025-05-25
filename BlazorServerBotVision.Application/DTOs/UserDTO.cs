namespace BlazorServerBotVision.Application.DTOs
{
    public class UserDTO : BaseDTO
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    } 
}