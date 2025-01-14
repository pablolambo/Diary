namespace Diary.Application.Handlers.Entries;

using Domain.Entities;
using Domain.Interfaces;
using MediatR;

public class CreateEntryCommand : IRequest<Guid>
{
    public string Content { get; init; } = string.Empty;
    public string Title { get; init; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
}

public class CreateEntryCommandHandler : IRequestHandler<CreateEntryCommand, Guid>
{
    private readonly IEntryRepository _entryRepository;
    private readonly IUserRepository _userRepository;

    public CreateEntryCommandHandler(IEntryRepository entryRepository, IUserRepository userRepository)
    {
        _entryRepository = entryRepository;
        _userRepository = userRepository;
    }

    public async Task<Guid> Handle(CreateEntryCommand request, CancellationToken cancellationToken)
    {
        var entry = new EntryEntity
        {
            Title = request.Title,
            Content = request.Content,
            Date = DateTime.UtcNow.Date,
            Id = Guid.NewGuid(),
            UserId = request.UserId
        };

        await _entryRepository.AddAsync(entry, cancellationToken);
        var user = await _userRepository.GetUserById(request.UserId, cancellationToken);
        var userStats = user.Statistics;

        userStats.TotalEntries++;
        if (userStats.TotalEntries == 1)
        {
            userStats.FirstEntryDate = DateTime.UtcNow.Date;
        }

        userStats.LastEntryDate = DateTime.UtcNow.Date;
        CheckCurrentDayStreak(userStats);

        await _userRepository.UpdateUser(user, cancellationToken);
        
        return entry.Id;
    }

    private static void CheckCurrentDayStreak(UserStatisticsEntity userStats)
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