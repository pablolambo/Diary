namespace Diary.Application.DTOs;

public sealed record NotificationDto
{
    public string Title { get; init; } = string.Empty;
    public string Message { get; init; } = string.Empty;
}