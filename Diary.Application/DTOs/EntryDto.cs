namespace Diary.Application.DTOs;

public class EntryDto
{
    public DateTime Date { get; set; } = DateTime.UtcNow;
    public string Title { get; set; } = "Title";
    public string Content { get; set; } = "Write your content...";
}