namespace BlazorServerBotVision.Application.DTOs
{
    public class ChatHistoryDTO : BaseDTO
    {
        public string UserId { get; set; } = string.Empty;
        public DateTime Lastmodified { get; set; } = DateTime.UtcNow;
        public string Prompt { get; set; } = string.Empty;
        public string AIResponse { get; set; } = string.Empty;
        public string DBResponse { get; set; } = string.Empty;
    }
}