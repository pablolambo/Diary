﻿namespace Diary.Application.Utilities;

using System.Numerics;
using Domain.Entities;

public class UserStatisticsUtilities
{
    public static UserStatisticsEntity UpdateCurrentDayStreak(UserStatisticsEntity userStats)
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

    public static UserStatisticsEntity UpdateAverageEntriesPerWeek(UserStatisticsEntity userStats)
    {
        if (userStats.TotalEntries == 0 || !userStats.FirstEntryDate.HasValue || !userStats.LastEntryDate.HasValue)
        {
            userStats.AverageEntriesPerWeek = 0;
        }
        else
        {
            var daysDifference = Math.Max(1, Math.Round((userStats.LastEntryDate.Value - userStats.FirstEntryDate.Value).TotalDays));
            var weeks = Math.Round(daysDifference / 7, 2);
            if (weeks < 1)
            {
                userStats.AverageEntriesPerWeek = userStats.TotalEntries;
            }
            else
            {
                userStats.AverageEntriesPerWeek = Math.Round(userStats.TotalEntries / weeks, 2);
            }
        }

        return userStats;
    }

}