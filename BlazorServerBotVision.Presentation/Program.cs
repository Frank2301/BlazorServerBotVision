using Blazored.SessionStorage;
using BlazorServerBotVision.Application.Extensions;
using BlazorServerBotVision.Application.Interfaces;
using BlazorServerBotVision.Application.Services;
using BlazorServerBotVision.Infrastructure.Extensions;
using BlazorServerBotVision.Persistence.Extensions;
using BlazorServerBotVision.Presentation.Services;
using Microsoft.AspNetCore.Components.Authorization;
using AppSession = BlazorServerBotVision.Application.Interfaces.ISessionStorageService;
using BlzSession = Blazored.SessionStorage.ISessionStorageService;



var builder = WebApplication.CreateBuilder(args);

builder.Configuration
  .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
  .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
  .AddEnvironmentVariables();
if (builder.Environment.IsDevelopment())
    builder.Configuration.AddUserSecrets<Program>();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddBlazoredSessionStorage(); 
builder.Services.AddScoped<AppSession, BlazoredSessionStorageAdapter>();


builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<CustomAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(
    sp => sp.GetRequiredService<CustomAuthenticationStateProvider>());
builder.Services.AddScoped<IAuthenticationStateHandler>(
    sp => sp.GetRequiredService<CustomAuthenticationStateProvider>());

builder.Services.AddApplicationServices();

builder.Services.AddPersistenceServices(builder.Configuration);

builder.Services.AddInfrastructureServices();


var redisConn = builder.Configuration.GetConnectionString("Redis");
if (!string.IsNullOrWhiteSpace(redisConn)
    && builder.Environment.IsProduction())
{
    builder.Services.AddStackExchangeRedisCache(opts =>
    {
        opts.Configuration = redisConn;
        opts.InstanceName = "BotVision:";
    });
}
else
{
    builder.Services.AddDistributedMemoryCache();
}

builder.Services.AddScoped<IChatOrchestrationService, ChatOrchestrationService>();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.Run();