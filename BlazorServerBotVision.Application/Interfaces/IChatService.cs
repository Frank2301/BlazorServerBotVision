namespace BlazorServerBotVision.Application.Interfaces;

using BlazorServerBotVision.Application.DTOs;


public interface IChatService
{
    Task SaveChatAsync(ChatDTO chatDto, Guid userId);
    Task<IEnumerable<ChatDTO>> GetUserChatsAsync(Guid userId);
}