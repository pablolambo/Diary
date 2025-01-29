namespace Diary.UnitTests;

using Application.Utilities;
using Domain.Entities;

public class EntryTests
{
    [Test]
    public async Task UpdateAverageEntriesPerWeek_UserCreates1EntryPerDayIn1Week_ShouldReturn7AverageEntriesPerWeek()
    {
        var userStatistics = new UserStatisticsEntity
        {
            TotalEntries = 7,
            FirstEntryDate = DateTime.UtcNow.Date.AddDays(-7),
            LastEntryDate = DateTime.UtcNow.Date
        };
    
        var userStatisticsResult = UserStatisticsUtilities.UpdateAverageEntriesPerWeek(userStatistics);
    
        Assert.NotNull(userStatisticsResult);
        Assert.That(userStatisticsResult.AverageEntriesPerWeek, Is.EqualTo(7));
    }
    
    [Test]
    public async Task UpdateAverageEntriesPerWeek_UserCreates10EntriesIn2Weeks_ShouldReturn5AverageEntriesPerWeek()
    {
        var userStatistics = new UserStatisticsEntity
        {
            TotalEntries = 10,
            FirstEntryDate = DateTime.UtcNow.Date.AddDays(-14),
            LastEntryDate = DateTime.UtcNow.Date
        };
    
        var userStatisticsResult = UserStatisticsUtilities.UpdateAverageEntriesPerWeek(userStatistics);
    
        Assert.NotNull(userStatisticsResult);
        Assert.That(userStatisticsResult.AverageEntriesPerWeek, Is.EqualTo(5));
    }


}