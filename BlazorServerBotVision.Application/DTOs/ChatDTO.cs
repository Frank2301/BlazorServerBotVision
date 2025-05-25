namespace BlazorServerBotVision.Application.DTOs
{
    public class ChatDTO : BaseDTO
    {
        public string Prompt { get; set; } = string.Empty;
        public string AIResponse { get; set; } = string.Empty;
    }
}