using BlazorServerBotVision.Application.DTOs;

namespace BlazorServerBotVision.Application.Interfaces;

public interface IChatDatabaseService
{
    Task<string> GetDatabaseResultAsync(string userPrompt);
    Task SaveChatMessageAsync(ChatHistoryDTO chatMessage);
    Task DeleteChatMessageAsync(Guid id);
}
