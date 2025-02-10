namespace Diary.UnitTests;

using Application.Utilities;
using Domain.Entities;
using Domain.Interfaces;
using Moq;

public class BadgesTests
{
    private readonly Mock<IBadgeRepository> _badgeRepositoryMock;
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly BadgesUtilities _badgesUtilities;
    private readonly UserStatisticsUtilities _userStatisticsUtilities;
    
    public BadgesTests()
    {
        _badgeRepositoryMock = new Mock<IBadgeRepository>();
        _userRepositoryMock = new Mock<IUserRepository>();
               
        _badgesUtilities = new BadgesUtilities(_badgeRepositoryMock.Object, _userRepositoryMock.Object);
        _userStatisticsUtilities =  new UserStatisticsUtilities();
        
        var badges = CreateBadges();

        _badgeRepositoryMock
            .Setup(repo => repo.GetBadgesAsync())
            .ReturnsAsync(badges);

        _userRepositoryMock
            .Setup(repo => repo.UpdateUser(It.IsAny<DiaryUserEntity>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);
    }

    [Test]
    public async Task UserBadgesAwarded_UserHasNoBadgesAndIsAwardableFor10TotalEntries_ShouldReturnListOfBadgesWithOne10TotalEntriesBadge()
    {
        var user = new DiaryUserEntity
        {
            Statistics = new UserStatisticsEntity
            {
                CurrentDayStreak = 0,
                TotalEntries = 10
            },
            EarnedBadges = new List<UserBadgeEntity>()
        };

        var badgesAwarded = await _badgesUtilities.UserBadgesAwarded(user, CancellationToken.None);

        Assert.That(badgesAwarded, Is.Not.Null);
        Assert.That(badgesAwarded, Has.Count.EqualTo(2));
        _userRepositoryMock.Verify(repo => repo.UpdateUser(It.IsAny<DiaryUserEntity>(), It.IsAny<CancellationToken>()), Times.Exactly(2));
        Assert.Multiple(() =>
        {
            Assert.That(badgesAwarded[0].Name, Is.EqualTo("Your first entry"));
            Assert.That(badgesAwarded[1].Name, Is.EqualTo("10 total entries"));
        });
    }

    [Test]
    public async Task UpdateCurrentDayStreak_UserHasZeroDayStreak_ShouldUpdateCurrentDayStreakToOne()
    {
        var userStatistics = new UserStatisticsEntity
        {
            CurrentDayStreak = 0,
            TotalEntries = 1
        };
        
        var userStatisticsResult = UserStatisticsUtilities.UpdateCurrentDayStreak(userStatistics);
        
        Assert.That(userStatisticsResult, Is.Not.Null);
        Assert.That(userStatisticsResult.CurrentDayStreak, Is.EqualTo(1));
    }
    
    [Test]
    public async Task UpdateCurrentDayStreak_UserHasOneDayStreakFromYesterday_ShouldUpdateCurrentDayStreakToTwo()
    {
        var userStatistics = new UserStatisticsEntity
        {
            CurrentDayStreak = 1,
            TotalEntries = 2,
            LastEntryDate = DateTime.UtcNow.Date.AddDays(-1),
            FirstEntryDate = DateTime.UtcNow.Date.AddDays(-2)
        };
        
        var userStatisticsResult = UserStatisticsUtilities.UpdateCurrentDayStreak(userStatistics);
        
        Assert.That(userStatisticsResult, Is.Not.Null);
        Assert.That(userStatisticsResult.CurrentDayStreak, Is.EqualTo(2));
    }

    private static List<BadgeEntity> CreateBadges()
    {
        var badges = new List<BadgeEntity>
        {
            new() 
            {
                Id = Guid.NewGuid(),
                Name = "Your first entry",
                Type = BadgeType.TotalEntries,
                Value = 1
            }, new()
            {
                Id = Guid.NewGuid(),
                Name = "3 day streak",
                Type = BadgeType.Streak,
                Value = 3
            }, new()
            {
                Id = Guid.NewGuid(),
                Name = "5 day streak",
                Type = BadgeType.Streak,
                Value = 5
            }, new()
            {
                Id = Guid.NewGuid(),
                Name = "7 day streak",
                Type = BadgeType.Streak,
                Value = 7
            }, new()
            {
                Id = Guid.NewGuid(),
                Name = "10 total entries",
                Type = BadgeType.TotalEntries,
                Value = 10
            }, new()
            {
                Id = Guid.NewGuid(),
                Name = "25 total entries",
                Type = BadgeType.TotalEntries,
                Value = 25
            }, new()
            {
                Id = Guid.NewGuid(),
                Name = "50 total entries",
                Type = BadgeType.TotalEntries,
                Value = 50
            }
        };
        return badges;
    }
}

// Naming your tests
//     The name of your test should consist of three parts:
//
//     1. The name of the method being tested.
//     2. The scenario under which it's being tested.
//     3. The expected behavior when the scenario is invoked.

// good example: Add_SingleNumber_ReturnsSameNumber

// [Fact]
// public void Add_EmptyString_ReturnsZero()
// {
//     // Arrange
//     var stringCalculator = new StringCalculator();
//
//     // Act
//     var actual = stringCalculator.Add("");
//
//     // Assert
//     Assert.Equal(0, actual);
// }