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
    public List<string>? TagNames { get; set; } = new();
}

public class CreateEntryCommandHandler : IRequestHandler<CreateEntryCommand, (Guid, List<BadgeEntity>)>
{
    private readonly IEntryRepository _entryRepository;
    private readonly IUserRepository _userRepository;
    private readonly IBadgeRepository _badgeRepository;
    private readonly UserStatisticsUtilities _userStatisticsUtilities;
    private readonly BadgesUtilities _badgesUtilities;
    private readonly ITagsRepository _tagsRepository;

    public CreateEntryCommandHandler(IEntryRepository entryRepository, 
        IUserRepository userRepository,
        IBadgeRepository badgeRepository, 
        ITagsRepository tagsRepository)
    {
        _entryRepository = entryRepository;
        _userRepository = userRepository;
        _badgeRepository = badgeRepository;
        _tagsRepository = tagsRepository;

        _badgesUtilities = new BadgesUtilities(_badgeRepository, _userRepository);
        _userStatisticsUtilities = new UserStatisticsUtilities();
    }

    public async Task<(Guid, List<BadgeEntity>)> Handle(CreateEntryCommand request, CancellationToken cancellationToken)
    {
        var newEntryId = Guid.NewGuid();
        var (newUserTags, oldTags) = await ResolveTags(request, newEntryId, cancellationToken);
        var tagsCombined = new List<TagEntity>(oldTags.Concat(newUserTags));

        var entry = new EntryEntity
        {
            Title = request.Title,
            Content = request.Content,
            Date = DateTime.UtcNow,
            Id = newEntryId,
            UserId = request.UserId!,
            EntryTags = tagsCombined
        };

        await _entryRepository.AddAsync(entry, cancellationToken);
        var user = await _userRepository.GetUserById(request.UserId!, cancellationToken);

        user.Statistics.TotalEntries++;
        if (user.Statistics.TotalEntries == 1)
        {
            user.Statistics.FirstEntryDate = DateTime.UtcNow;
        }
        
        user.EntryTags.AddRange(newUserTags);
        
        user.Statistics = UserStatisticsUtilities.UpdateCurrentDayStreak(user.Statistics);
        user.Statistics.LastEntryDate = DateTime.UtcNow;
        
        user.Statistics = UserStatisticsUtilities.UpdateAverageEntriesPerWeek(user.Statistics);
        
        var badgesAwarded = await _badgesUtilities.UserBadgesAwarded(user, cancellationToken);

        user.Statistics.Points += 25;
        
        await _userRepository.UpdateUser(user, cancellationToken);
        
        return (entry.Id, badgesAwarded);
    }

    private async Task<(List<TagEntity> newTags, List<TagEntity> oldTags)> ResolveTags(CreateEntryCommand request, Guid newEntryId, CancellationToken cancellationToken)
    {
        var userTags = await _tagsRepository.SearchByTagNames(request.TagNames!, request.UserId!, cancellationToken);

        var newTags = request.TagNames!.Except(userTags.Select(t => t.Name)).ToList();

        var newTagEntities = new List<TagEntity>();
        if (newTags.Count != 0)
        {
            newTagEntities = newTags.Select(tagName => new TagEntity
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId!,
                Name = tagName,
                EntryEntityId = newEntryId
            }).ToList();
        }
        
        return (newTagEntities, userTags);
    }
}