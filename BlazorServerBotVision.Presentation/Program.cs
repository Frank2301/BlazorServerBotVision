using Blazored.SessionStorage;
using BlazorServerBotVision.Application.Extensions;
using BlazorServerBotVision.Application.Interfaces;
using BlazorServerBotVision.Application.Services;
using BlazorServerBotVision.Infrastructure.Extensions;
using BlazorServerBotVision.Persistence.Extensions;
using BlazorServerBotVision.Presentation.Services;
using Microsoft.AspNetCore.Components.Authorization;


var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddUserSecrets<Program>();
}

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddBlazoredSessionStorage();

builder.Services.AddScoped<BlazorServerBotVision.Application.Interfaces.ISessionStorageService, BlazoredSessionStorageAdapter>();

builder.Services.AddAuthorizationCore();

builder.Services.AddScoped<CustomAuthenticationStateProvider>();

builder.Services.AddScoped<AuthenticationStateProvider>(provider =>
    provider.GetRequiredService<CustomAuthenticationStateProvider>());

builder.Services.AddScoped<IAuthenticationStateHandler>(provider =>
    provider.GetRequiredService<CustomAuthenticationStateProvider>());

builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddInfrastructureServices();

builder.Services.AddScoped<BlazorServerBotVision.Application.Interfaces.IAuthenticationService, BlazorServerBotVision.Application.Services.AuthenticationService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();