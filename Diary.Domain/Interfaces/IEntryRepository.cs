namespace Diary.Domain.Interfaces;

using Entities;

public interface IEntryRepository
{
    Task AddAsync(Entry entry, CancellationToken cancellationToken);
    Task<Entry?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<Entry>> GetAllAsync(DateTime from, DateTime to, CancellationToken cancellationToken);
    Task UpdateAsync(Entry entry, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
}