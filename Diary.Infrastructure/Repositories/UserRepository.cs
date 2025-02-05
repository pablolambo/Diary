namespace Diary.Infrastructure.Repositories;

using Domain.Entities;
using Domain.Interfaces;
using Domain.Models;
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

    public async Task<List<UserTheme>> GetUserThemes(string diaryUserId, CancellationToken cancellationToken)
    {
        var unlockedThemes = await _dbContext.Users
            .Include(u => u.UserTheme)
            .Where(u => u.Id == diaryUserId)
            .Select(u => u.UserTheme)
            .FirstOrDefaultAsync(cancellationToken);

        return unlockedThemes ?? new List<UserTheme>();
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
            .Include(u => u.UserTheme)
            .Include(u => u.UnlockedBadges)
            .Include(u => u.Statistics)
            .FirstOrDefaultAsync(u => u.Id == diaryUserId, cancellationToken: cancellationToken);

        return user ?? new();
    }

    public async Task SeedThemes(string diaryUserId, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users
            .Include(u => u.UserTheme)
            .FirstOrDefaultAsync(u => u.Id == diaryUserId, cancellationToken);

        if (user == null)
        {
            throw new Exception("User not found");
        }

        if (user.UserTheme == null || user.UserTheme.Count == 0)
        {
            user.UserTheme =
            [
                new()
                {
                    Id = Guid.NewGuid(), PrimaryColor = "Default", SecondaryColor = "", IsSelected = true,
                    IsBought = true, Cost = 0, UserId = diaryUserId
                },

                new()
                {
                    Id = Guid.NewGuid(), PrimaryColor = "Red", SecondaryColor = "White", IsSelected = false,
                    IsBought = false, Cost = 100, UserId = diaryUserId
                },

                new()
                {
                    Id = Guid.NewGuid(), PrimaryColor = "Green", SecondaryColor = "Light green", IsSelected = false,
                    IsBought = false, Cost = 125, UserId = diaryUserId
                },

                new()
                {
                    Id = Guid.NewGuid(), PrimaryColor = "Blue", SecondaryColor = "Light blue", IsSelected = false,
                    IsBought = false, Cost = 150, UserId = diaryUserId
                }
            ];
            
            //_dbContext.Users.ExecuteUpdateAsync(user, cancellationToken: cancellationToken);
            await _dbContext.UserThemes.AddRangeAsync(user.UserTheme, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }

}