namespace Diary.Domain.Entities;

using Microsoft.AspNetCore.Identity;

public class DiaryUserEntity : IdentityUser
{
    public bool IsDailyReminderEnabled { get; init; }
    public UserStatisticsEntity Statistics { get; set; } = new();
    public List<ThemeEntity> UnlockedThemes { get; set; } = new();
    public List<BadgeEntity> UnlockedBadges { get; set; } = new();
    public List<TagEntity> EntryTags { get; set; } = new();
    public string FirebaseToken { get; set; }
}