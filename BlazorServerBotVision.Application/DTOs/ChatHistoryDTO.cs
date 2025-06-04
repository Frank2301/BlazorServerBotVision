namespace BlazorServerBotVision.Application.DTOs
{
    public class ChatHistoryDTO : BaseDTO
    {       
        public Guid UserId { get; init; }
        public DateTime LastModified { get; init; } = DateTime.UtcNow;
        public string Prompt { get; init; } = string.Empty;
        public string AIResponse { get; init; } = string.Empty;
        public string DBResponse { get; init; } = string.Empty;
    }
}
