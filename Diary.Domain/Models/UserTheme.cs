namespace Diary.Domain.Models;

public class UserTheme
{
    public Guid Id { get; set; }
    public string UserId { get; set; }
    public string PrimaryColor { get; set; } = string.Empty;
    public string SecondaryColor { get; set; } = string.Empty;
    public bool IsSelected { get; set; } = false;
    public bool IsBought { get; set; } = false;
    public int Cost { get; set; }
}