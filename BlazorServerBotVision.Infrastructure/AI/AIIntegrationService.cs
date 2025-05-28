using BlazorServerBotVision.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using OpenAI.Chat;

namespace BlazorServerBotVision.Infrastructure.AI
{
    public class AiIntegrationService : IChatAIService
    {
        private readonly ChatClient _chatClient;

        public AiIntegrationService(IConfiguration configuration)
        {
            var apiKey = configuration["OpenAI:ApiKey"];
            if (string.IsNullOrWhiteSpace(apiKey))
                throw new ArgumentException("Der OpenAI API Key fehlt in der Konfiguration.");

            _chatClient = new ChatClient("gpt-4", apiKey);
        }

        public async Task<string> GetAiGeneratedChatAsync(string userPrompt)
        {
            if (string.IsNullOrWhiteSpace(userPrompt))
                throw new ArgumentException("Der Benutzerprompt darf nicht leer sein.", nameof(userPrompt));

            var messages = new List<ChatMessage>
            {
                new UserChatMessage(userPrompt)
            };

            try
            {
                var completionResult = await _chatClient.CompleteChatAsync(messages);
                var chatCompletion = completionResult.Value;
                var aiResponse = chatCompletion.Content?.LastOrDefault()?.Text?.Trim();

                return string.IsNullOrWhiteSpace(aiResponse)
                    ? "Es tut mir leid, aber es wurde keine Antwort generiert."
                    : aiResponse;
            }
            catch (Exception ex)
            {          
                return "Entschuldigung, es gab einen Fehler bei der AI Anfrage. Bitte versuche es später erneut.";
            }
        }
    }
}
