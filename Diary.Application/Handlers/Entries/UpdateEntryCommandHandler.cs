﻿namespace Diary.Application.Handlers.Entries;

using Domain.Entities;
using Domain.Interfaces;
using MediatR;

public class UpdateEntryCommand : IRequest<Guid>
{
    public Guid? EntryId { get; set; }
    public string Content { get; set; }
    public string Title { get; set; }
    public List<string>? TagNames { get; set; }
    public string? UserId { get; set; }
}

public class UpdateEntryCommandHandler : IRequestHandler<UpdateEntryCommand, Guid>
{
    private readonly IEntryRepository _repository;
    private readonly ITagsRepository _tagsRepository;
    private readonly IUserRepository _userRepository;
    
    public UpdateEntryCommandHandler(IEntryRepository repository,
        ITagsRepository tagsRepository, 
        IUserRepository userRepository)
    {
        _repository = repository;
        _tagsRepository = tagsRepository;
        _userRepository = userRepository;
    }

    public async Task<Guid> Handle(UpdateEntryCommand request, CancellationToken cancellationToken)
    {
        var (newUserTags, oldTags) = await ResolveTags(request, cancellationToken);
        var tagsCombined = new List<TagEntity>(oldTags.Concat(newUserTags));
        
        var entry = await _repository.GetByEntryIdAsync(request.EntryId!.Value, cancellationToken);

        if (entry == null) return Guid.Empty;
        
        entry.Content = request.Content;
        entry.Title = request.Title;
        entry.EntryTags = tagsCombined;

        var user = await _userRepository.GetUserById(request.UserId!, cancellationToken);

        if (user == null) throw new Exception($"User {request.UserId} not found");
        
        user.EntryTags.AddRange(newUserTags);
        
        await _repository.UpdateAsync(entry, cancellationToken);
        await _userRepository.UpdateUser(user, cancellationToken);

        return entry.Id;
    }
    
    private async Task<(List<TagEntity> newTags, List<TagEntity> oldTags)> ResolveTags(UpdateEntryCommand request, CancellationToken cancellationToken)
    {
        var userTags = await _tagsRepository.SearchByTagNames(request.TagNames!, request.UserId!, cancellationToken);

        var newTags = request.TagNames!.Except(userTags.Select(t => t.Name)).ToList();

        var newTagEntities = new List<TagEntity>();
        if (newTags.Count != 0)
        {
            newTagEntities = newTags.Select(tagName => new TagEntity
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                Name = tagName,
                EntryEntityId = request.EntryId!.Value
            }).ToList();
        }
        
        return (newTagEntities, userTags);
    }
}