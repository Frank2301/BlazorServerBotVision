namespace BlazorServerBotVision.Application.DTOs;

public class ChatDTO : BaseDTO
{
    public string Prompt { get; init; } = string.Empty;
    public string AIResponse { get; init; } = string.Empty;
}