namespace Diary.Application.DTOs;

using Domain.Entities;

public class UserStatistics
{ 
    public int TotalEntries { get; set; }
    public DateTime? FirstEntryDate { get; set; }
    public DateTime? LastEntryDate { get; set; }
    public int LongestStreakDay { get; set; }
    public double AverageEntriesPerWeek { get; set; }
    public int FavoriteEntries { get; set; }
    public List<string> MostUsedTags { get; set; } = new();

    public static UserStatistics ToDto(UserStatisticsEntity s)
    {
        return new UserStatistics
        {
            FavoriteEntries = s.FavoriteEntries,
            TotalEntries = s.TotalEntries,
            FirstEntryDate = s.FirstEntryDate,
            LastEntryDate = s.LastEntryDate,
            LongestStreakDay = s.CurrentDayStreak,
            MostUsedTags = s.MostUsedTags,
            AverageEntriesPerWeek = s.AverageEntriesPerWeek
        };
    }
}