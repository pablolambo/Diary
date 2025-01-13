namespace Diary.Application.DTOs;

public class DiaryUserDto
{
    public bool IsDailyReminderEnabled { get; init; } = false;
    public List<NotificationDto> Notifications { get; set; } = new();
}