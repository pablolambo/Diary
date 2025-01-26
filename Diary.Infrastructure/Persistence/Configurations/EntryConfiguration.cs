namespace Diary.Infrastructure.Persistence.Configurations;

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class EntryConfiguration : IEntityTypeConfiguration<EntryEntity>
{
    public void Configure(EntityTypeBuilder<EntryEntity> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Title).IsRequired().HasMaxLength(200);
        builder.Property(e => e.Content).IsRequired();
        builder.Property(e => e.Date).IsRequired();
    }
}