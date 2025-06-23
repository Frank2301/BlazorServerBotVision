namespace BlazorServerBotVision.Application.DTOs;
public abstract class BaseDTO
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
}