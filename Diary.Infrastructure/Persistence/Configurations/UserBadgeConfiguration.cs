namespace Diary.Infrastructure.Persistence.Configurations;

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserBadgeConfiguration : IEntityTypeConfiguration<UserBadgeEntity>
{
    public void Configure(EntityTypeBuilder<UserBadgeEntity> builder)
    {
        builder.HasKey(ub => ub.Id);

        builder.HasOne(ub => ub.User)
            .WithMany(u => u.EarnedBadges)
            .HasForeignKey(ub => ub.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(ub => ub.Badge)
            .WithMany()
            .HasForeignKey(ub => ub.BadgeId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(ub => new { ub.UserId, ub.BadgeId })
            .IsUnique();
    }
}