using BlazorServerBotVision.Application.DTOs;


namespace BlazorServerBotVision.Application.Interfaces
{
    public interface IChatHistoryService
    {
        Task<IEnumerable<ChatHistoryDTO>> GetChatHistoryAsync(string userId);
        Task AddChatHistoryAsync(ChatHistoryDTO chatHistoryDto);
    }
}