namespace Diary.Application.Queries;

using System.Text.Json.Serialization;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

public class GetEntriesQuery : IRequest<IEnumerable<EntryEntity>>
{
    [JsonIgnore]
    public string? UserId { get; set; } = string.Empty;
    public DateTime From { get; set; }
    public DateTime To { get; set; }
}

public class GetEntriesQueryHandler : IRequestHandler<GetEntriesQuery, IEnumerable<EntryEntity>>
{
    private readonly IEntryRepository _repository;

    public GetEntriesQueryHandler(IEntryRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<EntryEntity>> Handle(GetEntriesQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetByDateRangeAsync(request.UserId!, request.From, request.To, cancellationToken);
    }
}