namespace Diary.Domain.Entities;

using Microsoft.AspNetCore.Identity;
using Models;

public class DiaryUserEntity : IdentityUser
{
    public bool IsDailyReminderEnabled { get; init; }
    public UserStatisticsEntity Statistics { get; set; } = new();
    public List<BadgeEntity> UnlockedBadges { get; set; } = new();
    public List<TagEntity> EntryTags { get; set; } = new();

    public List<UserTheme> UserTheme { get; set; }
    public string? FirebaseToken { get; set; } = string.Empty;
}