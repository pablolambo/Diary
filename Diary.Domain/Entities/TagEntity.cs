namespace Diary.Domain.Entities;

public class TagEntity
{
    public Guid Id { get; set; }
    public Guid EntryEntityId { get; set; }
    public List<EntryEntity>? EntryEntity { get; set; }
    public string Name { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
}