namespace Diary.Infrastructure.Persistence.Configurations;

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class NotificationsConfiguration : IEntityTypeConfiguration<NotificationEntity>
{
    public void Configure(EntityTypeBuilder<NotificationEntity> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Title).IsRequired().HasMaxLength(32);
        builder.Property(n => n.Message).IsRequired().HasMaxLength(100);
        builder.Property(n => n.DiaryUserId).IsRequired().HasMaxLength(450);
        
        builder.Property(n => n.ScheduledTime).IsRequired();

        builder.HasOne(n => n.DiaryUser)
            .WithMany(u => u.Notifications)
            .HasForeignKey(n => n.DiaryUserId);
    }
}