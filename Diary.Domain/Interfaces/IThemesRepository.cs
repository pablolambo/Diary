namespace Diary.Domain.Interfaces;

using Entities;

public interface IThemesRepository
{
    Task<List<ThemeEntity>> GetThemesAsync();
}