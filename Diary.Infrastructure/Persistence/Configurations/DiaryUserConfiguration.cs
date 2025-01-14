namespace Diary.Infrastructure.Persistence.Configurations;

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class DiaryUserConfiguration : IEntityTypeConfiguration<DiaryUserEntity>
{
    public void Configure(EntityTypeBuilder<DiaryUserEntity> builder)
    {
        builder.HasKey(e => e.DiaryUserId);
        builder.Property(u => u.DiaryUserId).IsRequired().HasMaxLength(32);
    }
}