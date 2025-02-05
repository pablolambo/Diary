namespace Diary.Application.Handlers.Entries;

using Domain.Interfaces;
using MediatR;

public sealed record DeleteEntryCommand(Guid Id, string UserId) : IRequest<bool>;

public class DeleteEntryCommandHandler : IRequestHandler<DeleteEntryCommand, bool>
{
    private readonly IEntryRepository _entriesRepository;
    private readonly IUserRepository _userRepository;

    public DeleteEntryCommandHandler(IEntryRepository entriesRepository,
        IUserRepository userRepository)
    {
        _entriesRepository = entriesRepository;
        _userRepository = userRepository;
    }

    public async Task<bool> Handle(DeleteEntryCommand request, CancellationToken cancellationToken)
    {
        await _entriesRepository.DeleteAsync(request.Id, cancellationToken);
     
        var user = await _userRepository.GetUserById(request.UserId, cancellationToken);
        user.Statistics.TotalEntries--;
        await _userRepository.UpdateUser(user, cancellationToken);
        
        return true;
    }
}