namespace Diary.Application.Handlers.Entries;

using System.Text.Json.Serialization;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

public class CreateEntryCommand : IRequest<(Guid, List<BadgeEntity>)>
{
    public string Content { get; init; } = string.Empty;
    public string Title { get; init; } = string.Empty;
    [JsonIgnore]
    public string? UserId { get; set; } = string.Empty;
}

public class CreateEntryCommandHandler : IRequestHandler<CreateEntryCommand, (Guid, List<BadgeEntity>)>
{
    private readonly IEntryRepository _entryRepository;
    private readonly IUserRepository _userRepository;
    private readonly IBadgeRepository _badgeRepository;

    public CreateEntryCommandHandler(IEntryRepository entryRepository, 
        IUserRepository userRepository, 
        IBadgeRepository badgeRepository)
    {
        _entryRepository = entryRepository;
        _userRepository = userRepository;
        _badgeRepository = badgeRepository;
    }

    public async Task<(Guid, List<BadgeEntity>)> Handle(CreateEntryCommand request, CancellationToken cancellationToken)
    {
        var entry = new EntryEntity
        {
            Title = request.Title,
            Content = request.Content,
            Date = DateTime.UtcNow,
            Id = Guid.NewGuid(),
            UserId = request.UserId!
        };

        await _entryRepository.AddAsync(entry, cancellationToken);
        var user = await _userRepository.GetUserById(request.UserId!, cancellationToken);
        var userStats = user.Statistics;

        userStats.TotalEntries++;
        if (userStats.TotalEntries == 1)
        {
            userStats.FirstEntryDate = DateTime.UtcNow;
        }

        userStats.LastEntryDate = DateTime.UtcNow;
        UpdateCurrentDayStreak(userStats);

        var badgesAwarded = await UserBadgesAwarded(user, cancellationToken);

        user.Statistics.Points += 25;
        
        await _userRepository.UpdateUser(user, cancellationToken);
        
        return (entry.Id, badgesAwarded);
    }

    private async Task<List<BadgeEntity>> UserBadgesAwarded(DiaryUserEntity user, CancellationToken cancellationToken)
    {
        var badges = await _badgeRepository.GetBadgesAsync();
        var streakBadges = badges.Where(b => b.Type == BadgeType.Streak).ToList();
        var totalEntriesBadges = badges.Where(b => b.Type == BadgeType.TotalEntries).ToList();
        var badgesAwarded = new List<BadgeEntity>();

        foreach (var streakBadge in streakBadges)
        {
            if (user.Statistics.CurrentDayStreak >= streakBadge.Value)
            {
                if (user.UnlockedBadges.All(unlockedBadge => unlockedBadge.Name != streakBadge.Name))
                {
                    badgesAwarded.Add(streakBadge);
                }
                
                if (user.UnlockedBadges.Count == 0)
                {
                    badgesAwarded.Add(streakBadge);
                }
            }
        }
        
        foreach (var totalEntriesBadge in totalEntriesBadges)
        {
            if (user.Statistics.TotalEntries >= totalEntriesBadge.Value)
            {
                if (user.UnlockedBadges.All(unlockedBadge => unlockedBadge.Name != totalEntriesBadge.Name))
                {
                    badgesAwarded.Add(totalEntriesBadge);
                }

                if (user.UnlockedBadges.Count == 0)
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
        user.UnlockedBadges.Add(badge);
        user.Statistics.Points += 500;
        await _userRepository.UpdateUser(user, cancellationToken);
    }

    private static void UpdateCurrentDayStreak(UserStatisticsEntity userStats)
    {
        if (userStats.LastEntryDate.HasValue && userStats.FirstEntryDate.HasValue)
        {
            var yesterday = DateTime.UtcNow.Date.AddDays(-1);
            if (userStats.LastEntryDate.Value.Date == yesterday)
            {
                userStats.CurrentDayStreak++;
            }
            else if (userStats.LastEntryDate.Value.Date < yesterday)
            {
                userStats.CurrentDayStreak = 1;
            }
        }
        else
        {
            userStats.CurrentDayStreak = 1;
        }
    }
}