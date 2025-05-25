using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
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
                throw new ArgumentException("Der OpenAI-API-Key fehlt in der Konfiguration.");

            // Initialisiere den ChatClient mit dem gewünschten Modell (hier "gpt-4")
            _chatClient = new ChatClient("gpt-4", apiKey);
        }

        public async Task<string> GetAiGeneratedChatAsync(string userPrompt)
        {
            if (string.IsNullOrWhiteSpace(userPrompt))
                throw new ArgumentException("Der Benutzer-Prompt darf nicht leer sein.", nameof(userPrompt));

            // Erstelle die Chatnachricht mittels der speziell vorgesehenen Klasse UserChatMessage
            var messages = new List<ChatMessage>
            {
                new UserChatMessage(userPrompt)
            };

            // Sende die Nachrichten an die API – dies liefert ein ClientResult<ChatCompletion>
            var completionResult = await _chatClient.CompleteChatAsync(messages);

            // Entpacke das Ergebnis über die Value-Eigenschaft
            var chatCompletion = completionResult.Value;

            // In der aktuellen API enthält chatCompletion.Content eine Liste von ChatMessage-Objekten.
            // Wir nehmen hier beispielsweise das letzte Element – in einfachen Szenarien enthält diese Liste nur eine Antwort.
            var aiResponse = chatCompletion.Content?.LastOrDefault()?.Text?.Trim();

            return string.IsNullOrWhiteSpace(aiResponse)
                ? "Es tut mir leid, aber es wurde keine Antwort generiert."
                : aiResponse;
        }
    }
}
