namespace Diary.Infrastructure.Persistence.Configurations;

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class EntryTagEntityConfiguration : IEntityTypeConfiguration<EntryTagEntity>
{
    public void Configure(EntityTypeBuilder<EntryTagEntity> builder)
    {
        builder.HasKey(e => e.Id);

        // builder.HasOne(et => et.Entry)
        //     .WithMany(e => e.EntryTags)
        //     .HasForeignKey(et => et.EntryId);
    }
}