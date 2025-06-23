namespace BlazorServerBotVision.Domain.Interfaces;

using BlazorServerBotVision.Domain.Entities;

public interface IUserRepository
{
    Task<User?> FindByEmailAsync(string email);
    Task<User> GetByIdAsync(Guid id);
    Task<IEnumerable<User>> GetAllAsync();
    Task AddAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(Guid id);
    Task<User> GetByEmailAsync(string email);
}