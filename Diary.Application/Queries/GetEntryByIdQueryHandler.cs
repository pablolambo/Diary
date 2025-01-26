namespace Diary.Application.Queries;

using Domain.Entities;
using Domain.Interfaces;
using MediatR;

public sealed record GetEntryByIdQuery(Guid EntryId) : IRequest<EntryEntity>;

public class GetEntryByIdQueryHandler : IRequestHandler<GetEntryByIdQuery, EntryEntity>
{
    private readonly IEntryRepository _repository;

    public GetEntryByIdQueryHandler(IEntryRepository repository)
    {
        _repository = repository;
    }

    public async Task<EntryEntity?> Handle(GetEntryByIdQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetByEntryIdAsync(request.EntryId, cancellationToken);
    }
}
