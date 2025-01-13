namespace Diary.Application.Queries;

using Domain.Entities;
using Domain.Interfaces;
using MediatR;

public sealed record GetEntriesQuery(DateTime From, DateTime To) : IRequest<IEnumerable<EntryEntity>>;

public class GetEntriesQueryHandler : IRequestHandler<GetEntriesQuery, IEnumerable<EntryEntity>>
{
    private readonly IEntryRepository _repository;

    public GetEntriesQueryHandler(IEntryRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<EntryEntity>> Handle(GetEntriesQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync(request.From, request.To, cancellationToken);
    }
}