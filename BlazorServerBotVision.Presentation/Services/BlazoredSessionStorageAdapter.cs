namespace BlazorServerBotVision.Presentation.Services;

using BlazorServerBotVision.Application.Interfaces;
using BlazoredStorage = Blazored.SessionStorage.ISessionStorageService; 


public class BlazoredSessionStorageAdapter : ISessionStorageService
{
    private readonly BlazoredStorage _blazoredSessionStorage;

    public BlazoredSessionStorageAdapter(BlazoredStorage sessionStorage)
    {
        _blazoredSessionStorage = sessionStorage;
    }

    public async Task SetItemAsync<T>(string key, T value)
    {
        await _blazoredSessionStorage.SetItemAsync(key, value);
    }

    public async Task<T> GetItemAsync<T>(string key)
    {
        return await _blazoredSessionStorage.GetItemAsync<T>(key);
    }

    public async Task RemoveItemAsync(string key)
    {
        await _blazoredSessionStorage.RemoveItemAsync(key);
    }
}
