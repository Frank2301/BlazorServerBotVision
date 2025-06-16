namespace BlazorServerBotVision.Domain.Interfaces;

using BlazorServerBotVision.Domain.Entities;


public interface IChatHistoryRepository
{
    Task<IEnumerable<ChatHistory>> GetChatHistoryAsync(Guid userId);
    Task AddChatHistoryAsync(ChatHistory chatHistory);
}