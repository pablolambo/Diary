namespace Diary.Application.Utilities;

using Domain.Entities;
using Domain.Interfaces;

public class BadgesUtilities
{
    private readonly IBadgeRepository _badgeRepository;
    private readonly IUserRepository _userRepository;

    public BadgesUtilities(IBadgeRepository badgeRepository,
        IUserRepository userRepository)
    {
        _badgeRepository = badgeRepository;
        _userRepository = userRepository;
    }
    
    public async Task<List<BadgeEntity>> UserBadgesAwarded(DiaryUserEntity user, CancellationToken cancellationToken)
    {
        var badges = await _badgeRepository.GetBadgesAsync();
        var streakBadges = badges.Where(b => b.Type == BadgeType.Streak).ToList();
        var totalEntriesBadges = badges.Where(b => b.Type == BadgeType.TotalEntries).ToList();
        var badgesAwarded = new List<BadgeEntity>();

        foreach (var streakBadge in streakBadges)
        {
            if (user.Statistics.CurrentDayStreak >= streakBadge.Value)
            {
                if (user.EarnedBadges.All(unlockedBadge => unlockedBadge.Name != streakBadge.Name))
                {
                    badgesAwarded.Add(streakBadge);
                }
            }
        }
        
        foreach (var totalEntriesBadge in totalEntriesBadges)
        {
            if (user.Statistics.TotalEntries >= totalEntriesBadge.Value)
            {
                if (user.EarnedBadges.All(unlockedBadge => unlockedBadge.Name != totalEntriesBadge.Name))
                {
                    badgesAwarded.Add(totalEntriesBadge);
                }
            }
        }

        foreach (var badge in badgesAwarded)
        {
            await AwardUser(user, badge, cancellationToken);
        }

        return badgesAwarded;
    }
    
    private async Task AwardUser(DiaryUserEntity user, BadgeEntity badge, CancellationToken cancellationToken)
    {
        var hasEarnedBadge = user.EarnedBadges.Any(ub => ub.Name == badge.Name);
        if (hasEarnedBadge)
        {
            return;
        }

        var userBadge = new UserBadgeEntity
        {
            UserId = user.Id,
            BadgeId = badge.Id,
            DateEarned = DateTime.UtcNow,
            Value = badge.Value,
            Name = badge.Name,
            Type = badge.Type
        };

        user.EarnedBadges.Add(userBadge);
        
        user.Statistics.Points += 500;
        await _userRepository.UpdateUser(user, cancellationToken);
    }
}