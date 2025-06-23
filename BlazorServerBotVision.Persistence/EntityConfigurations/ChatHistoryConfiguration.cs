namespace BlazorServerBotVision.Persistence.EntityConfigurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BlazorServerBotVision.Domain.Entities;


public class ChatHistoryConfiguration : IEntityTypeConfiguration<ChatHistory>
{
    public void Configure(EntityTypeBuilder<ChatHistory> builder)
    {      
        builder.HasKey(ch => ch.Id);
     
        builder.Property(ch => ch.CreatedAt)
               .IsRequired()
               .HasDefaultValueSql("GETUTCDATE()");
        builder.Property(ch => ch.LastModified)
               .IsRequired()
               .HasDefaultValueSql("GETUTCDATE()");
        
        builder.Property(ch => ch.UserId)
               .IsRequired();
    
        builder.Property(ch => ch.Prompt)
               .IsRequired()
               .HasMaxLength(500);
        builder.Property(ch => ch.AIResponse)
               .IsRequired();
        builder.Property(ch => ch.DBResponse)
               .IsRequired();
       
        builder.HasOne(ch => ch.User)
               .WithMany(u => u.ChatHistories)
               .HasForeignKey(ch => ch.UserId)
               .OnDelete(DeleteBehavior.Cascade);
     
        builder.HasIndex(ch => ch.UserId)
               .HasDatabaseName("IX_ChatHistory_UserId");
    }
}