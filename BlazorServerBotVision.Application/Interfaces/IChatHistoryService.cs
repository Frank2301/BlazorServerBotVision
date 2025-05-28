using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorServerBotVision.Application.DTOs;

namespace BlazorServerBotVision.Application.Interfaces
{
    public interface IChatHistoryService
    {
        Task<IEnumerable<ChatHistoryDTO>> GetChatHistoryAsync(Guid userId);
        Task AddChatHistoryAsync(ChatHistoryDTO chatHistoryDto);
    }
}