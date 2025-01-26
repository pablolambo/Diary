namespace Diary.Domain.Entities;

public class BadgeEntity
{
    public Guid Id { get; init; }
    public string Name { get; set; } = string.Empty;
    public BadgeType Type { get; init; }
    public int Value { get; init; }
}

public enum BadgeType
{
    Streak,
    TotalEntries
}