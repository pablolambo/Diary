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

    public async Task UpdateTag(TagEntity tagEntity, CancellationToken cancellationToken)
    {
        _context.Tags.Update(tagEntity);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateTags(List<TagEntity> tagEntity, CancellationToken cancellationToken)
    {
        _context.Tags.UpdateRange(tagEntity);
        await _context.SaveChangesAsync(cancellationToken);    
    }
}