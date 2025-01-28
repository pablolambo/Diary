namespace Diary.Application.Handlers.Entries;

using Domain.Entities;
using Domain.Interfaces;
using MediatR;

public sealed record UpdateEntryCommand(Guid Id, string Content, string Title, List<string>? TagNames, string UserId) : IRequest<Guid>;

public class UpdateEntryCommandHandler : IRequestHandler<UpdateEntryCommand, Guid>
{
    private readonly IEntryRepository _repository;
    private readonly ITagsRepository _tagsRepository;


    public UpdateEntryCommandHandler(IEntryRepository repository,
        ITagsRepository tagsRepository)
    {
        _repository = repository;
        _tagsRepository = tagsRepository;
    }

    public async Task<Guid> Handle(UpdateEntryCommand request, CancellationToken cancellationToken)
    {
        var tagNames = request.TagNames;
        var userTags = new List<TagEntity>();
        if (tagNames != null && tagNames.Count != 0)
        {
            userTags = await ResolveTags(request, cancellationToken);
        }
        
        var entry = await _repository.GetByEntryIdAsync(request.Id, cancellationToken);

        if (entry == null) return Guid.Empty;
        
        entry.Content = request.Content;
        entry.Title = request.Title;
        entry.EntryTags = userTags;

        await _repository.UpdateAsync(entry, cancellationToken);

        return entry.Id;
    }
    
    private async Task<List<TagEntity>> ResolveTags(UpdateEntryCommand request, CancellationToken cancellationToken)
    {
        var userTags = await _tagsRepository.SearchByTagNames(request.TagNames!, request.UserId!, cancellationToken);

        var newTags = request.TagNames!.Except(userTags.Select(t => t.Name)).ToList();

        var newTagEntities = new List<TagEntity>();
        if (newTags.Count != 0)
        {
            newTagEntities = newTags.Select(tagName => new TagEntity
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId!,
                Name = tagName
            }).ToList();
            
            await _tagsRepository.AddTags(newTagEntities, cancellationToken);
        }
        
        userTags.AddRange(newTagEntities);
        return userTags;
    }
}