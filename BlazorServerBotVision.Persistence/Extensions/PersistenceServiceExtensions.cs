namespace BlazorServerBotVision.Persistence.Extensions;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using BlazorServerBotVision.Persistence.Database;
using BlazorServerBotVision.Persistence.Repositories;
using BlazorServerBotVision.Domain.Interfaces;


public static class PersistenceServiceExtensions
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
     
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IUserRepository, UserRepository>();     
        services.AddScoped<IChatHistoryRepository, ChatHistoryRepository>();

        return services;
    }
}
