namespace BlazorServerBotVision.Application.Interfaces;

using BlazorServerBotVision.Application.DTOs;


public interface IChatHistoryService
{
    Task<IEnumerable<ChatHistoryDTO>> GetChatHistoryAsync(Guid userId);
    Task AddChatHistoryAsync(ChatHistoryDTO chatHistoryDto);
}