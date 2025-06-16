namespace BlazorServerBotVision.Infrastructure.Database;

using BlazorServerBotVision.Application.DTOs;
using BlazorServerBotVision.Application.Interfaces;
using BlazorServerBotVision.Domain.Entities;
using BlazorServerBotVision.Persistence.Database;
using Microsoft.EntityFrameworkCore;


public class ChatDatabaseService : IChatDatabaseService
{
    private readonly ApplicationDbContext _context;

    public ChatDatabaseService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<string> GetDatabaseResultAsync(string userPrompt)
    {
        var results = await _context.ChatHistories
            .Where(ch => EF.Functions.Like(ch.Prompt, $"%{userPrompt}%"))
            .ToListAsync();

        if (results == null || !results.Any())
        {
            return "[Keine Einträge in der Datenbank gefunden]";
        }

        var combinedResults = string.Join(Environment.NewLine, results.Select(r =>
            $"Prompt: {r.Prompt} - Antwort: {r.DBResponse}"
        ));

        return combinedResults;
    }

    public async Task SaveChatMessageAsync(ChatHistoryDTO chatMessage)
    {
  
        var entity = new ChatHistory
        {             
            Id = chatMessage.Id,
            UserId = chatMessage.UserId,
            Prompt = chatMessage.Prompt,
            AIResponse = chatMessage.AIResponse,
            DBResponse = chatMessage.DBResponse,
            LastModified = chatMessage.CreatedAt
        };

        _context.ChatHistories.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteChatMessageAsync(Guid id)
    {           
        var chatEntity = await _context.ChatHistories.FindAsync(id);
        if (chatEntity != null)
        {
            _context.ChatHistories.Remove(chatEntity);
            await _context.SaveChangesAsync();
        }
    }
}
