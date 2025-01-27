namespace Diary.Domain.Entities;

public class EntryTagEntity
{
    public Guid Id { get; set; }
    public Guid EntryId { get; set; }
    public EntryEntity Entry { get; set; } = null!;
}