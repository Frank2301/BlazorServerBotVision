using BlazorServerBotVision.Application.Extensions;
using BlazorServerBotVision.Infrastructure.Extensions;
using BlazorServerBotVision.Persistence.Extensions;



var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddUserSecrets<Program>();
}

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddInfrastructureServices();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    // HSTS Standardwert, ggf. an Produktionsszenarien anpassen
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
