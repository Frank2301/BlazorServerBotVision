using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorServerBotVision.Application.DTOs;
using BlazorServerBotVision.Application.Interfaces;
using BlazorServerBotVision.Domain.Entities;
using BlazorServerBotVision.Domain.Interfaces;

namespace BlazorServerBotVision.Application.Services
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _chatRepository;

        public ChatService(IChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }

        public async Task<IEnumerable<ChatDTO>> GetUserChatsAsync(Guid userId)
        {
            var chats = await _chatRepository.GetUserChatsAsync(userId);
          
            return chats.Select(chat => new ChatDTO
            {
                Id = chat.Id,
                CreatedAt = chat.Timestamp,
                Prompt = chat.Prompt,
                AIResponse = chat.AIResponse
            });
        }

        public async Task SaveChatAsync(ChatDTO chatDto, Guid userId)
        {
            var chat = new Chat
            {
                UserId = userId,
                Prompt = chatDto.Prompt,
                AIResponse = chatDto.AIResponse,
                Timestamp = DateTime.UtcNow
            };

            await _chatRepository.SaveChatAsync(chat);
        }
    }
}
