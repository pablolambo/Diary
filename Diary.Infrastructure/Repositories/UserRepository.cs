namespace Diary.Infrastructure.Repositories;

using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

public class UserRepository : IUserRepository
{
    private readonly DiaryDbContext _dbContext;

    public UserRepository(DiaryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<DiaryUserEntity>> GetUsersWhoOptedForDailyNotification(CancellationToken cancellationToken)
    {
        var usersWithReminders = await _dbContext.Users
            .Where(u => u.IsDailyReminderEnabled)
            .ToListAsync(cancellationToken);

        return usersWithReminders;
    }

    public async Task<List<DiaryUserEntity>> GetUsers(CancellationToken cancellationToken)
    {
        var users = await _dbContext.Users.ToListAsync(cancellationToken: cancellationToken);

        return users;
    }

    public async Task<List<ThemeEntity>> GetUserUnlockedThemes(string diaryUserId, CancellationToken cancellationToken)
    {
        var unlockedThemes = await _dbContext.Users
            .Where(u => u.Id == diaryUserId)
            .Select(u => u.UnlockedThemes)
            .FirstOrDefaultAsync(cancellationToken);

        return unlockedThemes ?? new List<ThemeEntity>();
    }

    public async Task<UserStatisticsEntity> GetUserStatistics(string diaryUserId, CancellationToken cancellationToken)
    {
        var user = await GetUserById(diaryUserId, cancellationToken);

        var userStats = user.Statistics;
        
        return userStats;
    }

    public async Task UpdateUser(DiaryUserEntity user, CancellationToken cancellationToken)
    {
        _dbContext.Users.Update(user);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<DiaryUserEntity> GetUserById(string diaryUserId, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users
            .Include(u => u.EntryTags)
            .Include(u => u.UnlockedThemes)
            .Include(u => u.UnlockedBadges)
            .Include(u => u.Statistics)
            .FirstOrDefaultAsync(u => u.Id == diaryUserId, cancellationToken: cancellationToken);

        return user ?? new();
    }
}