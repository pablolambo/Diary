namespace Diary.Domain.Entities;

public class UserStatisticsEntity
{
    public int TotalEntries { get; set; }
    public DateTime? FirstEntryDate { get; set; }
    public DateTime? LastEntryDate { get; set; }
    public int CurrentDayStreak { get; set; }
    public double AverageEntriesPerWeek { get; set; }
    public int FavoriteEntries { get; set; }
    public List<string> MostUsedTags { get; set; } = new();
    public int Points { get; set; }
}