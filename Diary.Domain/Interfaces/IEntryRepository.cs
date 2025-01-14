namespace Diary.Domain.Interfaces;

using Entities;

public interface IEntryRepository
{
    Task AddAsync(EntryEntity entryEntity, CancellationToken cancellationToken);
    Task<EntryEntity?> GetByEntryIdAsync(Guid entryId, CancellationToken cancellationToken);
    Task<EntryEntity?> GetAllEntriesForUserAsync(string diaryUserId, CancellationToken cancellationToken);
    Task<IEnumerable<EntryEntity>> GetByDateRangeAsync(string diaryUserId, DateTime from, DateTime to,CancellationToken cancellationToken);
    Task UpdateAsync(EntryEntity entryEntity, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
}