namespace Diary.Application.Queries;

using Domain.Interfaces;
using DTOs;
using MediatR;

public sealed record GetThemeQuery(string UserId, Guid ThemeId) : IRequest<ThemeDto>;

public class GetThemeQueryHandler : IRequestHandler<GetThemeQuery, ThemeDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IThemesRepository _themesRepository;

    public GetThemeQueryHandler(IUserRepository userRepository,
        IThemesRepository themesRepository)
    {
        _userRepository = userRepository;
        _themesRepository = themesRepository;
    }

    public async Task<ThemeDto> Handle(GetThemeQuery request, CancellationToken cancellationToken)
    {
        var themeEntity = await _themesRepository.GetThemeByIdAsync(request.ThemeId, cancellationToken);
        if (themeEntity is null) throw new Exception($"Theme {request.ThemeId} not found.");
        
        var user = await _userRepository.GetUserById(request.UserId, cancellationToken);
        var isThemeUnlocked = user.UnlockedThemes.Contains(themeEntity);

        if (!isThemeUnlocked) return ThemeDto.ToDto(themeEntity);
        
        foreach (var theme in user.UnlockedThemes)
        {
            theme.IsSelected = false;
        }
        
        themeEntity.IsSelected = true;
        user.UnlockedThemes.Add(themeEntity);
        await _userRepository.UpdateUser(user, cancellationToken);

        return ThemeDto.ToDto(themeEntity);
    }
}