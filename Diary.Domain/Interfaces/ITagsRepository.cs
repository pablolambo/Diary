namespace Diary.Domain.Interfaces;

using Entities;

public interface ITagsRepository
{
    Task<List<TagEntity>> SearchByTagNames(List<string> tagName, string userId, CancellationToken cancellationToken);
    Task AddTag(TagEntity tagEntity, CancellationToken cancellationToken);
    Task AddTags(List<TagEntity> tagEntity, CancellationToken cancellationToken);
}