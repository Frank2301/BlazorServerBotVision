namespace BlazorServerBotVision.Application.Extensions;

using Microsoft.Extensions.DependencyInjection;
using BlazorServerBotVision.Application.Interfaces;
using BlazorServerBotVision.Application.Services;


public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {      
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
      
        services.AddScoped<IChatHistoryService, ChatHistoryService>();
     
        services.AddScoped<IChatOrchestrationService, ChatOrchestrationService>();

        return services;
    }
}