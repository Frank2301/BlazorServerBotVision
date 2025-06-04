using BlazorServerBotVision.Application.DTOs;
using BlazorServerBotVision.Application.Interfaces;
using BlazorServerBotVision.Domain.Entities;
using BlazorServerBotVision.Domain.Interfaces;

namespace BlazorServerBotVision.Application.Services
{
    public class ChatHistoryService : IChatHistoryService
    {
        private readonly IChatHistoryRepository _chatHistoryRepository;

        public ChatHistoryService(IChatHistoryRepository chatHistoryRepository)
        {
            _chatHistoryRepository = chatHistoryRepository;
        }

        public async Task<IEnumerable<ChatHistoryDTO>> GetChatHistoryAsync(Guid userId)
        {
            var chatHistories = await _chatHistoryRepository.GetChatHistoryAsync(userId);
          
            return chatHistories.Select(chat => new ChatHistoryDTO
            {
                Id = chat.Id,
                UserId = chat.UserId,
                LastModified = chat.LastModified,
                Prompt = chat.Prompt,
                AIResponse = chat.AIResponse,
                DBResponse = chat.DBResponse
            });
        }

        public async Task AddChatHistoryAsync(ChatHistoryDTO chatHistoryDto)
        {
            var chatHistory = new ChatHistory
            {
                UserId = chatHistoryDto.UserId,
                LastModified = chatHistoryDto.LastModified,
                Prompt = chatHistoryDto.Prompt,
                AIResponse = chatHistoryDto.AIResponse,
                DBResponse = chatHistoryDto.DBResponse
            };

            await _chatHistoryRepository.AddChatHistoryAsync(chatHistory);
        }
    }
}