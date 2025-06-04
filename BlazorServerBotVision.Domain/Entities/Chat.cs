
namespace BlazorServerBotVision.Domain.Entities
{
    public class Chat
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }
        public User User { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public string Prompt { get; set; } = string.Empty;
        public string AIResponse { get; set; } = string.Empty;
        public string DBResponse { get; set; } = string.Empty;
        public bool IsSaved { get; set; } = false;
    }
}