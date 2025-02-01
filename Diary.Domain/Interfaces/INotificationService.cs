namespace Diary.Domain.Interfaces;

using Application.DTOs;

public interface INotificationService
{
    Task<bool> SendNotificationToDeviceAsync(MessageModelEntity input);
}