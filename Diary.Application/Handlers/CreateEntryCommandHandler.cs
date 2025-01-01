namespace Diary.Application.Handlers;

using Domain.Entities;
using Domain.Interfaces;
using MediatR;

public sealed record CreateEntryCommand(string Content, string Title) : IRequest<Guid>;

public class CreateEntryCommandHandler : IRequestHandler<CreateEntryCommand, Guid>
{
    private readonly IEntryRepository _repository;

    public CreateEntryCommandHandler(IEntryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CreateEntryCommand request, CancellationToken cancellationToken)
    {
        var entry = new Entry
        {
            Title = request.Title,
            Content = request.Content
        };

        await _repository.AddAsync(entry, cancellationToken);
        
        return entry.Id;
    }
}