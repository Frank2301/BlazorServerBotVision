using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorServerBotVision.Domain.Entities;

namespace BlazorServerBotVision.Domain.Interfaces
{
    public interface IChatRepository
    {
        Task<IEnumerable<Chat>> GetUserChatsAsync(Guid userId);
        Task SaveChatAsync(Chat chat);
    }
}
