namespace Diary.Infrastructure.Repositories;

using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

public class BadgeRepository : IBadgeRepository
{
    private readonly DiaryDbContext _context;

    public BadgeRepository(DiaryDbContext context)
    {
        _context = context;
    }

    public async Task<List<BadgeEntity>> GetBadgesAsync()
    {
        var badges = await _context.Badges.ToListAsync();
        
        return badges;
    }
}