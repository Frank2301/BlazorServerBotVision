using Microsoft.EntityFrameworkCore;
using BlazorServerBotVision.Domain.Entities;
using BlazorServerBotVision.Domain.Interfaces;
using BlazorServerBotVision.Persistence.Database;

public class ChatRepository : IChatRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ChatRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Chat>> GetUserChatsAsync(string userId)
    {
        return await _dbContext.Chats
            .Where(chat => chat.UserId == userId)
            .OrderByDescending(chat => chat.Timestamp)
            .ToListAsync();
    }

    public async Task SaveChatAsync(Chat chat)
    {
        _dbContext.Chats.Add(chat);
        await _dbContext.SaveChangesAsync();
    }
}