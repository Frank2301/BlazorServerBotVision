using BlazorServerBotVision.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorServerBotVision.Persistence.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<ChatHistory> ChatHistories { get; set; }
    }
}
