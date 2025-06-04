using Microsoft.Extensions.DependencyInjection;
using BlazorServerBotVision.Application.Services;
using BlazorServerBotVision.Application.Interfaces;




namespace BlazorServerBotVision.Application.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IChatService, ChatService>();
            services.AddScoped<IChatHistoryService, ChatHistoryService>();  

            return services;
        }
    }
}