namespace Diary.Domain.Services;

using Entities;

public interface INotificationService
{ 
    Task SendNotificationAsync(string diaryUserId, NotificationEntity notification, CancellationToken cancellationToken);
}