namespace Diary.Infrastructure.Services;

using Diary.Domain.Services;
using Domain.Entities;
using Persistence;

public class NotificationService : INotificationService
{
    private readonly DiaryDbContext _dbContext;

    public NotificationService(DiaryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task SendNotificationAsync(string diaryUserId, NotificationEntity notification, CancellationToken cancellationToken)
    {
        //_dbContext.Notifcations.Add(notification);

        throw new NotImplementedException();
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}