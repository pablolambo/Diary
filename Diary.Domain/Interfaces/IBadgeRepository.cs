namespace Diary.Domain.Interfaces;

using Entities;

public interface IBadgeRepository
{
    Task<List<BadgeEntity>> GetBadgesAsync();
}