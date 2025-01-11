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

    public async Task AddAsync(Entry entry, CancellationToken cancellationToken)
    {
        await _dbContext.Entries.AddAsync(entry, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<Entry?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.Entries
            .FirstOrDefaultAsync(entry => entry.Id == id, cancellationToken);
    }

    public async Task<IEnumerable<Entry>> GetAllAsync(DateTime from, DateTime to, CancellationToken cancellationToken)
    {
        return await _dbContext.Entries.Where(e => e.Date >= from && e.Date <= to).ToListAsync(cancellationToken);
    }

    public async Task UpdateAsync(Entry entry, CancellationToken cancellationToken)
    {
        _dbContext.Entries.Update(entry);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var entry = await GetByIdAsync(id, cancellationToken);
        if (entry != null)
        {
            _dbContext.Entries.Remove(entry);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}