namespace Diary.Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

public class DiaryDbContext(DbContextOptions<DiaryDbContext> options) : IdentityDbContext<DiaryUserEntity>(options)
{
    public DbSet<EntryEntity> Entries { get; set; }
    public DbSet<NotificationEntity> Notifications { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DiaryDbContext).Assembly);
    }
}


