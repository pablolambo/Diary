namespace Diary.Application.DTOs;

public class MessageModelEntity
{
    public string Title { get; set; }
    public string Body { get; set; }
    public List<string> DeviceToken { get; set; }
    public string JsonDataString { get; set; } //In Database it is stored as Jsonb column
}