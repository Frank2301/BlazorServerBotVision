using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorServerBotVision.Application.DTOs;

namespace BlazorServerBotVision.Application.Interfaces
{
    public interface IChatOrchestrationService
    {   
        Task<ChatHistoryDTO> AskAsync(Guid userId, string prompt, bool persist = true);
        Task<IEnumerable<ChatHistoryDTO>> GetHistoryAsync(Guid userId);
        Task DeleteAsync(Guid userId, Guid historyId);
    }
}