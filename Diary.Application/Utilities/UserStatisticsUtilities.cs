namespace Diary.Application.Utilities;

using Domain.Entities;

public class UserStatisticsUtilities
{
    public UserStatisticsEntity UpdateCurrentDayStreak(UserStatisticsEntity userStats)
    {
        if (userStats.LastEntryDate.HasValue && userStats.FirstEntryDate.HasValue)
        {
            var yesterday = DateTime.UtcNow.Date.AddDays(-1);
            if (userStats.LastEntryDate.Value.Date == yesterday)
            {
                userStats.CurrentDayStreak++;
            }
            else if (userStats.LastEntryDate.Value.Date < yesterday)
            {
                userStats.CurrentDayStreak = 1;
            }
        }
        else
        {
            userStats.CurrentDayStreak = 1;
        }

        return userStats;
    }
}