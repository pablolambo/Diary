namespace Diary.Application.DTOs;

public class DiaryUserDto
{
    public bool IsDailyReminderEnabled { get; init; } = false;
    public List<NotificationDto> Notifications { get; set; } = new();
    public UserStatisticsDto StatisticsDto { get; set; } = new();
    public List<ThemeDto> UnlockedThemes { get; set; } = new();
    public List<BadgeDto> UnlockedBadges { get; set; } = new();
}