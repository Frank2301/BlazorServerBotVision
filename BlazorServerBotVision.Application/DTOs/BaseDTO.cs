namespace BlazorServerBotVision.Application.DTOs
{
    public abstract class BaseDTO
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}