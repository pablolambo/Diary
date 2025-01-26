namespace Diary.Infrastructure.Repositories;

using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

public class ThemesRepository : IThemesRepository
{
    private readonly DiaryDbContext _context;

    public ThemesRepository(DiaryDbContext context)
    {
        _context = context;
    }

    public Task<List<ThemeEntity>> GetThemesAsync()
    {
        var themes = _context.Themes.ToListAsync();
        
        return themes;
    }
}