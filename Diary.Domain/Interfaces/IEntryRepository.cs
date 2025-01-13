namespace Diary.Domain.Interfaces;

using Entities;

public interface IEntryRepository
{
    Task AddAsync(EntryEntity entryEntity, CancellationToken cancellationToken);
    Task<EntryEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<EntryEntity>> GetAllAsync(DateTime from, DateTime to, CancellationToken cancellationToken);
    Task UpdateAsync(EntryEntity entryEntity, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
}