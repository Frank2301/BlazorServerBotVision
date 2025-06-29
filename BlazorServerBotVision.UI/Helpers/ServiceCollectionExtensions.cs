using Microsoft.Extensions.DependencyInjection;

namespace BlazorServerBotVision.UI.Helpers
{
    public static class ServiceCollectionExtensions
    {   
        public static IServiceCollection AddSpeechUI(this IServiceCollection services)
        {    
            return services;
        }
    }
}
