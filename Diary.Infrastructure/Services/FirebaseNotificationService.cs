namespace Diary.Infrastructure.Services;

using Application.DTOs;
using Domain.Interfaces;
using FirebaseAdmin.Messaging;
using Microsoft.Extensions.Logging;

public class FirebaseNotificationService : INotificationService
{
    private readonly ILogger<FirebaseNotificationService> _logger;

    public FirebaseNotificationService(ILogger<FirebaseNotificationService> logger)
    {
        _logger = logger;
    }
    public async Task<bool> SendNotificationToDeviceAsync(MessageModelEntity input)
    {
        if (input.DeviceToken == null || input.JsonDataString == null)
        {
            return false;
        }

        foreach (var token in input.DeviceToken)
        {
            try
            {
                var message = new Message
                {
                    Notification = new FirebaseAdmin.Messaging.Notification
                    {
                        Title = input.Title,
                        Body = input.Body
                    },
                    Data = new Dictionary<string, string>
                    {
                        ["JsonData"] = input.JsonDataString
                    },
                    Token = token,
                    Android = new AndroidConfig
                    {
                        Notification = new AndroidNotification
                        {
                            Title = input.Title,
                            Body = input.Body,
                            Sound = "Default"
                        }
                    }
                };

                var messaging = FirebaseMessaging.DefaultInstance;
                var result = await messaging.SendAsync(message);

                if (string.IsNullOrEmpty(result))
                {
                    _logger.LogError($"{token} Device Token caused an error {result}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while creating notification {ex}");
            }
        }
        return true;
    }
}