using BlazorServerBotVision.Application.DTOs;

namespace BlazorServerBotVision.Application.Interfaces
{
    public interface IChatService
    {
        Task SaveChatAsync(ChatDTO chatDto, Guid userId);
        Task<IEnumerable<ChatDTO>> GetUserChatsAsync(Guid userId);
    }
}
