namespace BlazorServerBotVision.Application.Interfaces;

using BlazorServerBotVision.Application.DTOs;


public interface IChatDatabaseService
{
    Task<string> GetDatabaseResultAsync(string userPrompt);
    Task SaveChatMessageAsync(ChatHistoryDTO chatMessage);
    Task DeleteChatMessageAsync(Guid id);
}