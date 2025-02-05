namespace Diary.Application.Handlers.Themes;

using Domain.Interfaces;
using MediatR;

public sealed record BuyThemeCommand(Guid themeId, string UserId) : IRequest<Unit>;

public class BuyThemeCommandHandler : IRequestHandler<BuyThemeCommand, Unit>
{
    private readonly IUserRepository _userRepository;

    public BuyThemeCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Unit> Handle(BuyThemeCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserById(request.UserId, cancellationToken);
        var themes = user.UserTheme;
        var themeToBuy = themes.FirstOrDefault(t => t.Id == request.themeId);

        if (themeToBuy == null)
        {
            throw new Exception($"Theme {request.themeId} not found.");
        }

        if (themeToBuy.IsBought)
        {
            throw new Exception($"User {request.UserId} already has bought theme {request.themeId}.");
        }

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
        
        user.UserTheme.Add(themeToBuy);
        await _userRepository.UpdateUser(user, cancellationToken);
        
        return Unit.Value;
    }
}