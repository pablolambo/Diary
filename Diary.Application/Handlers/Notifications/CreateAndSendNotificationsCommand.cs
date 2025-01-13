namespace Diary.Application.Handlers.Notifications;

using Domain.Entities;
using Domain.Interfaces;
using Domain.Services;
using MediatR;

public sealed record CreateAndSendNotificationsCommand : IRequest, IRequest<Unit>;

public class CreateAndSendNotificationsCommandHandler : IRequestHandler<CreateAndSendNotificationsCommand, Unit>
{
    private readonly INotificationService _notificationService;
    private readonly IUserRepository _userRepository;

    public CreateAndSendNotificationsCommandHandler(INotificationService notificationService, IUserRepository userRepository)
    {
        _notificationService = notificationService;
        _userRepository = userRepository;
    }

    public async Task<Unit> Handle(CreateAndSendNotificationsCommand request, CancellationToken cancellationToken)
    {
        var usersWithReminders = await _userRepository.GetUsersWhoOptedForDailyNotification(cancellationToken);

        foreach (var user in usersWithReminders)
        {
            var notification = new NotificationEntity
            {
                Id = Guid.NewGuid(),
                DiaryUserId = user.DiaryUserId,
                Title = "Daily Reminder",
                Message = "Don't forget to write in your diary today!",
                ScheduledTime = DateTime.UtcNow
            };
            await _notificationService.SendNotificationAsync(user.DiaryUserId, notification, cancellationToken);
        }
        
        return Unit.Value;
    }
}