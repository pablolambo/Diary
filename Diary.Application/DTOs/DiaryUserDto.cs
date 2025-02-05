namespace Diary.Application.DTOs;

using Domain.Models;

public class DiaryUserDto
{
    public bool IsDailyReminderEnabled { get; init; } = false;
    public List<NotificationDto> Notifications { get; set; } = new();
    public UserStatisticsDto StatisticsDto { get; set; } = new();
    public List<UserTheme> Themes { get; set; } = new();
    public List<BadgeDto> UnlockedBadges { get; set; } = new();
}