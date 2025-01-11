﻿namespace Diary.Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

public class DiaryDbContext(DbContextOptions<DiaryDbContext> options) : IdentityDbContext<DiaryUser>(options)
{
    public DbSet<Entry> Entries { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DiaryDbContext).Assembly);
    }
}


