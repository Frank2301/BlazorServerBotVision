using BlazorServerBotVision.Application.DTOs;
using BlazorServerBotVision.Application.Interfaces;
using BlazorServerBotVision.Domain.Entities;
using BlazorServerBotVision.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace BlazorServerBotVision.Application.Services
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _chatRepository;

        public ChatService(IChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }

        public async Task<IEnumerable<ChatDTO>> GetUserChatsAsync(string userId)
        {
            var chats = await _chatRepository.GetUserChatsAsync(userId);
            var chatDtos = new List<ChatDTO>();

            foreach (var chat in chats)
            {
                chatDtos.Add(new ChatDTO
                {
                    Id = chat.Id,
                    CreatedAt = chat.Timestamp,
                    Prompt = chat.Prompt,
                    AIResponse = chat.AIResponse
                });
            }

            return chatDtos;
        }

        public async Task SaveChatAsync(ChatDTO chatDto, string userId)
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
