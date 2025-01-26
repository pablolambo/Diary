namespace Diary.Application.DTOs;

using Domain.Entities;

public class UserStatisticsDto
{ 
    public int TotalEntries { get; set; }
    public DateTime? FirstEntryDate { get; set; }
    public DateTime? LastEntryDate { get; set; }
    public int LongestStreakDay { get; set; }
    public double AverageEntriesPerWeek { get; set; }
    public int FavoriteEntries { get; set; }
    public List<string> MostUsedTags { get; set; } = new();
    public int Points { get; set; }

    public static UserStatisticsDto ToDto(UserStatisticsEntity s)
    {
        return new UserStatisticsDto
        {
            FavoriteEntries = s.FavoriteEntries,
            TotalEntries = s.TotalEntries,
            FirstEntryDate = s.FirstEntryDate,
            LastEntryDate = s.LastEntryDate,
            LongestStreakDay = s.CurrentDayStreak,
            MostUsedTags = s.MostUsedTags,
            AverageEntriesPerWeek = s.AverageEntriesPerWeek,
            Points = s.Points
        };
    }
}