namespace Diary.Application.Queries;

using Domain.Entities;
using Domain.Interfaces;
using MediatR;

public sealed record GetEntryByIdQuery(Guid EntryId) : IRequest<Entry>;

public class GetEntryByIdQueryHandler : IRequestHandler<GetEntryByIdQuery, Entry>
{
    private readonly IEntryRepository _repository;

    public GetEntryByIdQueryHandler(IEntryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Entry?> Handle(GetEntryByIdQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetByIdAsync(request.EntryId, cancellationToken);
    }
}
