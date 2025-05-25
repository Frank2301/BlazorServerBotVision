using BlazorServerBotVision.Application.DTOs;


namespace BlazorServerBotVision.Application.Interfaces
{
    public interface IChatService
    {
        Task SaveChatAsync(ChatDTO chatDto, string userId);
        Task<IEnumerable<ChatDTO>> GetUserChatsAsync(string userId);
    }
}