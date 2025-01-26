namespace Diary.Application.Responses;

using Domain.Entities;

public class CreateEntryResponse
{
    public Guid Id { get; set; }
    public List<BadgeEntity> BadgesAwarded { get; set; } = new();
}
