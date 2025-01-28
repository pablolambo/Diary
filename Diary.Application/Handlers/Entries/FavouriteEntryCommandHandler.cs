namespace Diary.Application.Handlers.Entries;

using Domain.Interfaces;
using MediatR;

public sealed record FavouriteEntryCommand(Guid Id, string UserId) : IRequest<Unit>;

public class FavouriteEntryCommandHandler : IRequestHandler<FavouriteEntryCommand, Unit>
{
    private readonly IEntryRepository _repository;
    private readonly IUserRepository _userRepository;

    public FavouriteEntryCommandHandler(IEntryRepository repository, IUserRepository userRepository)
    {
        _repository = repository;
        _userRepository = userRepository;
    }

    public async Task<Unit> Handle(FavouriteEntryCommand request, CancellationToken cancellationToken)
    {
        var entry = await _repository.GetByEntryIdAsync(request.Id, cancellationToken);

        if (entry == null)
            throw new Exception($"Entry with id {request.Id} not found.");
        
        var wasFavourite = entry.IsFavourite;
        
        entry.IsFavourite = !entry.IsFavourite;
        
        var user = await _userRepository.GetUserById(request.UserId, cancellationToken);

        if (wasFavourite)
            user.Statistics.FavoriteEntries--;
        else
            user.Statistics.FavoriteEntries++;
        
        await _userRepository.UpdateUser(user, cancellationToken);
        
        await _repository.UpdateAsync(entry, cancellationToken);
            
        return Unit.Value;
    }
}