using Microsoft.EntityFrameworkCore;
using BlazorServerBotVision.Domain.Entities;
using BlazorServerBotVision.Domain.Interfaces;
using BlazorServerBotVision.Persistence.Database;


namespace BlazorServerBotVision.Persistence.Repositories
{
    public class ChatHistoryRepository : IChatHistoryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ChatHistoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ChatHistory>> GetChatHistoryAsync(string userId) =>
            await _dbContext.ChatHistories.Where(ch => ch.UserId == userId).ToListAsync();

        public async Task AddChatHistoryAsync(ChatHistory chatHistory)
        {
            _dbContext.ChatHistories.Add(chatHistory);
            await _dbContext.SaveChangesAsync();
        }
    }
}