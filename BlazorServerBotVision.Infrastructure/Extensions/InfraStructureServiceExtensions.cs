using Microsoft.Extensions.DependencyInjection;
using BlazorServerBotVision.Application.Interfaces;
using BlazorServerBotVision.Infrastructure.AI;
using BlazorServerBotVision.Infrastructure.Database;

namespace BlazorServerBotVision.Infrastructure.Extensions;

public static class InfrastructureServiceExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {      
        services.AddScoped<IChatAIService, AiIntegrationService>();
        services.AddScoped<IChatDatabaseService, ChatDatabaseService>();

        return services;
    }
}