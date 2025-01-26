namespace Diary.Application.Handlers.Entries;

using Domain.Interfaces;
using MediatR;

public sealed record UpdateEntryCommand(Guid Id, string Content, string Title) : IRequest<Guid>;

public class UpdateEntryCommandHandler : IRequestHandler<UpdateEntryCommand, Guid>
{
    private readonly IEntryRepository _repository;

    public UpdateEntryCommandHandler(IEntryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(UpdateEntryCommand request, CancellationToken cancellationToken)
    {
        var entry = await _repository.GetByEntryIdAsync(request.Id, cancellationToken);

        if (entry == null) return Guid.Empty;
        
        entry.Content = request.Content;
        entry.Title = request.Title;

        await _repository.UpdateAsync(entry, cancellationToken);

        return entry.Id;
    }
}