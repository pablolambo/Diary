namespace Diary.Domain.Interfaces;

using Entities;
using Models;

public interface IUserRepository
{
    Task<List<DiaryUserEntity>> GetUsersWhoOptedForDailyNotification(CancellationToken cancellationToken);
    Task<List<DiaryUserEntity>> GetUsers(CancellationToken cancellationToken);
    Task<List<UserTheme>> GetUserThemes(string diaryUserId, CancellationToken cancellationToken);
    Task<UserStatisticsEntity> GetUserStatistics(string diaryUserId, CancellationToken cancellationToken);
    Task UpdateUser(DiaryUserEntity user, CancellationToken cancellationToken);
    Task<DiaryUserEntity> GetUserById(string diaryUserId, CancellationToken cancellationToken);
    Task SeedThemes(string diaryUserId, CancellationToken cancellationToken);
}