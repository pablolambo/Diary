namespace Diary.Application.DTOs;

using Domain.Entities;

public class ThemeDto
{
    public Guid Id { get; set; }
    public string PrimaryColor { get; set; } = string.Empty;
    public string SecondaryColor { get; set; } = string.Empty;
    public int Cost { get; set; }

    private static ThemeDto ToDto(ThemeEntity theme)
    {
        var dto = new ThemeDto
        {
            Id = theme.Id,
            PrimaryColor = theme.PrimaryColor,
            SecondaryColor = theme.SecondaryColor,
            Cost = theme.Cost
        };
        
        return dto;
    }
    
    public static List<ThemeDto> ListToDto(List<ThemeEntity> themes)
    {
        return themes.Select(ToDto).ToList();
    }
}