namespace Diary.Domain.Entities;

using System.ComponentModel.DataAnnotations;

public sealed record EntryEntity
{
    [Key] public Guid Id { get; init; }
    public DateTime Date { get; init; } = DateTime.UtcNow;
    public string? Title { get; set; }
    public string? Content { get; set; }

    public EntryEntity() { }
    
    public EntryEntity(string title, string content, DateTime date)
    {
        Id = Guid.NewGuid();
        Title = title;
        Content = content;
        Date = date;
    }
}