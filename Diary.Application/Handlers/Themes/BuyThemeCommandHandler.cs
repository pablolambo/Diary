namespace Diary.Application.Handlers.Themes;

using Domain.Interfaces;
using MediatR;

public sealed record BuyThemeCommand(Guid ThemeId, string UserId) : IRequest<Unit>;

public class BuyThemeCommandHandler : IRequestHandler<BuyThemeCommand, Unit>
{
    private readonly IThemesRepository _themesRepository;
    private readonly IUserRepository _userRepository;

    public BuyThemeCommandHandler(IThemesRepository themesRepository, IUserRepository userRepository)
    {
        _themesRepository = themesRepository;
        _userRepository = userRepository;
    }

    public async Task<Unit> Handle(BuyThemeCommand request, CancellationToken cancellationToken)
    {
        var unlockedThemes = await _userRepository.GetUserUnlockedThemes(request.UserId, cancellationToken);
        var themes = await _themesRepository.GetThemesAsync();
        var themeToBuy = themes.FirstOrDefault(t => t.Id == request.ThemeId);

        if (themeToBuy == null)
        {
            throw new Exception($"Theme {request.ThemeId} not found.");
        }

        if (unlockedThemes.Contains(themeToBuy))
        {
            throw new Exception($"User {request.UserId} already has theme {request.ThemeId}.");
        }

        var user = await _userRepository.GetUserById(request.UserId, cancellationToken);
        if (user == null)
        {
            throw new Exception($"User {request.UserId} not found.");
        }

        if (user.Statistics.Points < themeToBuy.Cost)
        {
            throw new Exception($"User {request.UserId} does not have enough points. Missing {themeToBuy.Cost - user.Statistics.Points} points.");
        }
        
        user.Statistics.Points -= themeToBuy.Cost;
        themeToBuy.IsBought = true;
        user.UnlockedThemes.Add(themeToBuy);
        await _userRepository.UpdateUser(user, cancellationToken);
        
        return Unit.Value;
    }
}