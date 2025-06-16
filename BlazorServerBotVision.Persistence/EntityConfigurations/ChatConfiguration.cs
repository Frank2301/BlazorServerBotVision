namespace BlazorServerBotVision.Persistence.EntityConfigurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BlazorServerBotVision.Domain.Entities;


public class ChatConfiguration : IEntityTypeConfiguration<Chat>
{
    public void Configure(EntityTypeBuilder<Chat> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.UserId)
               .IsRequired();

        builder.Property(c => c.Prompt)
               .IsRequired()
               .HasMaxLength(500);

        builder.Property(c => c.AIResponse)
               .IsRequired();

        builder.Property(c => c.DBResponse)
               .IsRequired();

        builder.Property(c => c.Timestamp)
               .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(c => c.IsSaved)
               .HasDefaultValue(false);
      
        builder.HasOne(c => c.User)
               .WithMany(u => u.Chats)
               .HasForeignKey(c => c.UserId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(c => c.UserId).HasDatabaseName("IX_Chat_UserId");
    }
}
