using Microsoft.Extensions.DependencyInjection;
using BlazorServerBotVision.Application.Interfaces;
using BlazorServerBotVision.Infrastructure.AI;

namespace BlazorServerBotVision.Infrastructure.Extensions;

public static class InfrastructureServiceExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
      
        services.AddScoped<IChatAIService, AiIntegrationService>();
       
        // services.AddScoped<ILoggingService, LoggingService>();
        // services.AddScoped<IEmailService, EmailService>();

        return services;
    }
}
