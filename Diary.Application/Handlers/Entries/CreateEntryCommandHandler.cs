namespace Diary.Application.Handlers.Entries;

using System.Text.Json.Serialization;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using Utilities;

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
    private readonly UserStatisticsUtilities _userStatisticsUtilities;
    private readonly BadgesUtilities _badgesUtilities;

    public CreateEntryCommandHandler(IEntryRepository entryRepository, 
        IUserRepository userRepository,
        IBadgeRepository badgeRepository)
    {
        _entryRepository = entryRepository;
        _userRepository = userRepository;
        _badgeRepository = badgeRepository;
        
        _badgesUtilities = new BadgesUtilities(_badgeRepository, _userRepository);
        _userStatisticsUtilities = new UserStatisticsUtilities();
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
        userStats = _userStatisticsUtilities.UpdateCurrentDayStreak(userStats);

        var badgesAwarded = await _badgesUtilities.UserBadgesAwarded(user, cancellationToken);

        userStats.Points += 25;
        
        await _userRepository.UpdateUser(user, cancellationToken);
        
        return (entry.Id, badgesAwarded);
    }
}