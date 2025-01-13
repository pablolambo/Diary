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

    public async Task<DiaryUserEntity> GetUserById(string diaryUserId, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.DiaryUserId == diaryUserId, cancellationToken: cancellationToken);

        return user ?? new();
    }
}