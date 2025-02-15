﻿namespace Diary.Infrastructure.Persistence;

using Configurations;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

public class DiaryDbContext(DbContextOptions<DiaryDbContext> options) : IdentityDbContext<DiaryUserEntity>(options)
{
    public DbSet<EntryEntity> Entries { get; set; }
    public DbSet<BadgeEntity> Badges { get; set; }
    public DbSet<TagEntity> Tags { get; set; }
    public DbSet<UserTheme> UserThemes { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DiaryDbContext).Assembly);
        
        modelBuilder.ApplyConfiguration(new DiaryUserConfiguration());
        modelBuilder.ApplyConfiguration(new EntryConfiguration());
        modelBuilder.ApplyConfiguration(new TagEntityConfiguration());
        
        modelBuilder.Entity<BadgeEntity>()
            .HasKey(b => b.Id);

        modelBuilder.Entity<BadgeEntity>()
            .Property(b => b.Name)
            .IsRequired()
            .HasMaxLength(100);
        
        SeedBadges(modelBuilder);
    }

    private static void SeedBadges(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BadgeEntity>().HasData(new BadgeEntity
        {
            Id = Guid.NewGuid(),
            Name = "Your first entry",
            Type = BadgeType.TotalEntries,
            Value = 1
        }, new BadgeEntity
        {
            Id = Guid.NewGuid(),
            Name = "3 day streak",
            Type = BadgeType.Streak,
            Value = 3
        }, new BadgeEntity
        {
            Id = Guid.NewGuid(),
            Name = "5 day streak",
            Type = BadgeType.Streak,
            Value = 5
        }, new BadgeEntity
        {
            Id = Guid.NewGuid(),
            Name = "7 day streak",
            Type = BadgeType.Streak,
            Value = 7
        }, new BadgeEntity
        {
            Id = Guid.NewGuid(),
            Name = "10 total entries",
            Type = BadgeType.TotalEntries,
            Value = 10
        }, new BadgeEntity
        {
            Id = Guid.NewGuid(),
            Name = "25 total entries",
            Type = BadgeType.TotalEntries,
            Value = 25
        }, new BadgeEntity
        {
            Id = Guid.NewGuid(),
            Name = "50 total entries",
            Type = BadgeType.TotalEntries,
            Value = 50
        });
    }
}


