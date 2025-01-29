namespace Diary.Infrastructure.Repositories;

using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

public class TagsRepository : ITagsRepository
{
    private readonly DiaryDbContext _context;

    public TagsRepository(DiaryDbContext context)
    {
        _context = context;
    }
    public async Task<List<TagEntity>> SearchByTagNames(List<string> tagNames, string userId, CancellationToken cancellationToken)
    {
        var lowercaseTagNames = tagNames.Select(t => t.ToLower()).ToList();
        
        var existingTags = await _context.Tags
            .Where(t => t.UserId == userId && lowercaseTagNames.Contains(t.Name.ToLower()))
            .ToListAsync(cancellationToken);
        
        return existingTags;
    }

    public async Task AddTag(TagEntity tagEntity, CancellationToken cancellationToken)
    {
        await _context.Tags.AddAsync(tagEntity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task AddTags(List<TagEntity> tagEntities, CancellationToken cancellationToken)
    {
        await _context.Tags.AddRangeAsync(tagEntities, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);    
    }
}