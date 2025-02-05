namespace Diary.Application.Handlers.Users;

using Domain.Interfaces;
using DTOs;
using MediatR;

public class CreateNotificationCommand : IRequest<bool>
{
    public List<string> DeviceTokens { get; set; } = new();
    public string Title { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public string JsonDataString { get; set; } = string.Empty;
}
    
public class CreateNotificationCommandHandler : IRequestHandler<CreateNotificationCommand, bool>
{
    private readonly INotificationService _notificationService;

    public CreateNotificationCommandHandler(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }
    
    public async Task<bool> Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
    {
        var messageModel = new MessageModelEntity
        {
            DeviceToken = request.DeviceTokens,
            Title = request.Title,
            Body = request.Body,
            JsonDataString = request.JsonDataString
        };

        return await _notificationService.SendNotificationToDeviceAsync(messageModel);
    }
}