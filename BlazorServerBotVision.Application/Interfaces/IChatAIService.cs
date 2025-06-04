
namespace BlazorServerBotVision.Application.Interfaces
{
    public interface IChatAIService
    {
        Task<string> GetAiGeneratedChatAsync(string userPrompt);
    }
}