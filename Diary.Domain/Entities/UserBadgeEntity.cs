namespace Diary.Domain.Entities;

public class UserBadgeEntity
{
    public Guid Id { get; init; }
    public string UserId { get; set; }
    public DiaryUserEntity User { get; set; }
    public Guid BadgeId { get; set; }
    public BadgeEntity Badge { get; set; }
    public DateTime DateEarned { get; set; }
    public string Name { get; set; } = string.Empty;
    public BadgeType Type { get; init; }
    public int Value { get; init; }
}