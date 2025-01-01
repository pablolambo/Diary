namespace Diary.Application.Handlers;

using Domain.Interfaces;
using MediatR;

public sealed record DeleteEntryCommand(Guid Id) : IRequest<bool>;

public class DeleteEntryCommandHandler : IRequestHandler<DeleteEntryCommand, bool>
{
    private readonly IEntryRepository _repository;

    public DeleteEntryCommandHandler(IEntryRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteEntryCommand request, CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(request.Id, cancellationToken);
        return true;
    }
}