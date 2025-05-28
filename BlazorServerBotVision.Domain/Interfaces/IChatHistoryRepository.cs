using BlazorServerBotVision.Domain.Entities;


namespace BlazorServerBotVision.Domain.Interfaces
{
    public interface IChatHistoryRepository
    {
        Task<IEnumerable<ChatHistory>> GetChatHistoryAsync(Guid userId);
        Task AddChatHistoryAsync(ChatHistory chatHistory);
    }
}