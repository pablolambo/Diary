namespace Diary.Domain.Entities;

public class ThemeEntity
{
    public Guid Id { get; set; }
    public string PrimaryColor { get; set; } = string.Empty;
    public string SecondaryColor { get; set; } = string.Empty;
    public int Cost { get; set; }
}