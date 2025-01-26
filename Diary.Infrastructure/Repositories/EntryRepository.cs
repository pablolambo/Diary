namespace Diary.Infrastructure.Repositories;

using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

public class EntryRepository : IEntryRepository
{
    private readonly DiaryDbContext _dbContext;

    public EntryRepository(DiaryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(EntryEntity entryEntity, CancellationToken cancellationToken)
    {
        await _dbContext.Entries.AddAsync(entryEntity, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<EntryEntity?> GetByEntryIdAsync(Guid entryId, CancellationToken cancellationToken)
    {
        return await _dbContext.Entries.FirstOrDefaultAsync(entry => entry.Id == entryId, cancellationToken);
    }

    public async Task<EntryEntity?> GetAllEntriesForUserAsync(string diaryUserId, CancellationToken cancellationToken)
    {
        return await _dbContext.Entries.FirstOrDefaultAsync(entry => entry.UserId == diaryUserId, cancellationToken);
    }

    public async Task<IEnumerable<EntryEntity>> GetByDateRangeAsync(string diaryUserId, DateTime from, DateTime to, CancellationToken cancellationToken)
    {
        return await _dbContext.Entries.Where(e => e.UserId == diaryUserId && e.Date >= from && e.Date <= to)
            .ToListAsync(cancellationToken);
    }

    public async Task UpdateAsync(EntryEntity entryEntity, CancellationToken cancellationToken)
    {
        _dbContext.Entries.Update(entryEntity);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var entry = await GetByEntryIdAsync(id, cancellationToken);
        if (entry != null)
        {
            _dbContext.Entries.Remove(entry);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}