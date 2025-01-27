namespace Diary.Domain.Interfaces;

using Entities;

public interface ITagsRepository
{
    Task<List<TagEntity>> SearchByTagNames(List<string> tagName, string userId, CancellationToken cancellationToken);
    Task UpdateTag(TagEntity tagEntity, CancellationToken cancellationToken);
    Task UpdateTags(List<TagEntity> tagEntity, CancellationToken cancellationToken);
}