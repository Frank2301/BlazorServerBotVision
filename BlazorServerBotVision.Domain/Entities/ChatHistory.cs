using System;

namespace BlazorServerBotVision.Domain.Entities
{
    public class ChatHistory
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; } // ehemals string
        public User User { get; set; }
        public DateTime LastModified { get; set; } = DateTime.UtcNow;
        public string Prompt { get; set; } = string.Empty;
        public string AIResponse { get; set; } = string.Empty;
        public string DBResponse { get; set; } = string.Empty;
    }
}
