namespace Diary.Domain.Entities;

public class NotificationEntity
{
    public Guid Id { get; set; }
    public string DiaryUserId { get; init; }
    public string Title { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public DateTime ScheduledTime { get; set; }
    public DateTime? SentTime { get; set; }
    public NotificationType Type { get; set; }
    public DiaryUserEntity? DiaryUser { get; set; }
}

public enum NotificationType
{
    Reminder,
    DayStreak
}