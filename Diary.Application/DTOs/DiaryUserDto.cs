namespace Diary.Application.DTOs;

public class DiaryUserDto
{
    public bool IsDailyReminderEnabled { get; init; } = false;
    public List<NotificationDto> Notifications { get; set; } = new();
    public UserStatistics Statistics { get; set; } = new();
}