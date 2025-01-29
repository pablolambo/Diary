namespace Diary.Domain.Interfaces;

using Entities;

public interface IThemesRepository
{
    Task<List<ThemeEntity>> GetThemesAsync();
    Task<ThemeEntity?> GetThemeByIdAsync(Guid themeId, CancellationToken cancellationToken);
}