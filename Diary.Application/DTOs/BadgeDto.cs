namespace Diary.Application.DTOs;

using Domain.Entities;

public sealed record BadgeDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public BadgeType Type { get; init; }
    public int Value { get; init; }

    private static BadgeDto ToDto(BadgeEntity badgeEntity)
    {
        return new BadgeDto
        {
            Id = badgeEntity.Id,
            Name = badgeEntity.Name,
            Type = badgeEntity.Type,
            Value = badgeEntity.Value
        };
    }

    public static List<BadgeDto> FromEntities(List<BadgeEntity> badgeEntities)
    {
        return badgeEntities.Select(ToDto).ToList();
    }
}