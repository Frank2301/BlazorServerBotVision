namespace BlazorServerBotVision.Domain.Interfaces;

using BlazorServerBotVision.Domain.Entities;

public interface IChatRepository
{
    Task<IEnumerable<Chat>> GetUserChatsAsync(Guid userId);
    Task SaveChatAsync(Chat chat);
}