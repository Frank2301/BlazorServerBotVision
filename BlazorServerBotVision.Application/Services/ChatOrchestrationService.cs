using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;
using BlazorServerBotVision.Application.DTOs;
using BlazorServerBotVision.Application.Interfaces;

namespace BlazorServerBotVision.Application.Services
{
    public class ChatOrchestrationService : IChatOrchestrationService
    {
        private readonly IChatAIService _ai;
        private readonly IChatDatabaseService _db;
        private readonly IChatHistoryService _history;
        private readonly IDistributedCache _cache;
        private const string CacheKeyPrefix = "chatHist_";
        private static readonly TimeSpan CacheTtl = TimeSpan.FromMinutes(15);

        public ChatOrchestrationService(
            IChatAIService aiService,
            IChatDatabaseService dbService,
            IChatHistoryService historyService,
            IDistributedCache distributedCache)
        {
            _ai = aiService;
            _db = dbService;
            _history = historyService;
            _cache = distributedCache;
        }

        public async Task<ChatHistoryDTO> AskAsync(Guid userId, string prompt, bool persist = true)
        {          
            var aiResponse = await _ai.GetAiGeneratedChatAsync(prompt);          
            var dbResponse = await _db.GetDatabaseResultAsync(prompt);
        
            var dto = new ChatHistoryDTO
            {
                UserId = userId,
                Prompt = prompt,
                AIResponse = aiResponse,
                DBResponse = dbResponse,
            };

            if (persist)
            {              
                await _db.SaveChatMessageAsync(dto);             
                await _cache.RemoveAsync(CacheKeyPrefix + userId);
            }
            return dto;
        }

        public async Task<IEnumerable<ChatHistoryDTO>> GetHistoryAsync(Guid userId)
        {
            var cacheKey = CacheKeyPrefix + userId;         
            var cached = await _cache.GetAsync(cacheKey);
            if (cached is not null)
            {
                return JsonSerializer.Deserialize<IEnumerable<ChatHistoryDTO>>(cached)!;
            }           
            var list = await _history.GetChatHistoryAsync(userId);          
            var bytes = JsonSerializer.SerializeToUtf8Bytes(list);
            await _cache.SetAsync(cacheKey, bytes,
                new DistributedCacheEntryOptions
                {
                    SlidingExpiration = CacheTtl
                });

            return list;
        }

        public async Task DeleteAsync(Guid userId, Guid historyId)
        {        
            await _db.DeleteChatMessageAsync(historyId);         
            await _cache.RemoveAsync(CacheKeyPrefix + userId);
        }
    }
}