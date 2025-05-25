using BlazorServerBotVision.Domain.Entities;
using BlazorServerBotVision.Domain.Interfaces;
using BlazorServerBotVision.Persistence.Database;
using Microsoft.EntityFrameworkCore;


namespace BlazorServerBotVision.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetByIdAsync(int id) => await _dbContext.Users.FindAsync(id);
        public async Task<IEnumerable<User>> GetAllAsync() => await _dbContext.Users.ToListAsync();
        public async Task AddAsync(User user) { _dbContext.Users.Add(user); await _dbContext.SaveChangesAsync(); }
        public async Task UpdateAsync(User user) { _dbContext.Users.Update(user); await _dbContext.SaveChangesAsync(); }
        public async Task DeleteAsync(int id) { var user = await _dbContext.Users.FindAsync(id); if (user != null) { _dbContext.Users.Remove(user); await _dbContext.SaveChangesAsync(); } }
    }
}
