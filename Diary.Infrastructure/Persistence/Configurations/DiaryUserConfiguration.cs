namespace Diary.Infrastructure.Persistence.Configurations;

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class DiaryUserConfiguration : IEntityTypeConfiguration<DiaryUserEntity>
{
    public void Configure(EntityTypeBuilder<DiaryUserEntity> builder)
    {
        builder.HasKey(e => e.Id);
        
        builder.OwnsOne(u => u.Statistics, statistics =>
        {
            statistics.Property(s => s.TotalEntries).IsRequired();
            statistics.Property(s => s.FirstEntryDate);
            statistics.Property(s => s.LastEntryDate);
            statistics.Property(s => s.CurrentDayStreak).IsRequired();
            statistics.Property(s => s.AverageEntriesPerWeek).IsRequired();
            statistics.Property(s => s.FavoriteEntries).IsRequired();
            statistics.Property(s => s.MostUsedTags)
                .HasConversion(tags => string.Join(',', tags),
                    tags => tags.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());
        });
    }
}