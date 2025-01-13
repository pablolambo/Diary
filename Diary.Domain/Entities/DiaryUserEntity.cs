namespace Diary.Domain.Entities;

using Microsoft.AspNetCore.Identity;

public class DiaryUserEntity : IdentityUser
{
    public bool IsDailyReminderEnabled { get; init; } = false;
    public string DiaryUserId { get; init; }
    public List<NotificationEntity> Notifications { get; set; } = new();
}