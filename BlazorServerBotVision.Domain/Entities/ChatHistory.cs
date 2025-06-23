namespace BlazorServerBotVision.Domain.Entities;

public class ChatHistory : BaseEntity
{   
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
    public DateTime LastModified { get; set; } = DateTime.UtcNow;
    public string Prompt { get; set; } = string.Empty;
    public string AIResponse { get; set; } = string.Empty;
    public string DBResponse { get; set; } = string.Empty;
}
