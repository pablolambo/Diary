namespace Diary.Application.Queries;

using Domain.Interfaces;
using Domain.Models;
using MediatR;

public sealed record SetThemeQuery(string UserId, Guid ThemeId) : IRequest<UserTheme>;

public class SetThemeQueryHandler : IRequestHandler<SetThemeQuery, UserTheme>
{
    private readonly IUserRepository _userRepository;

    public SetThemeQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserTheme> Handle(SetThemeQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserById(request.UserId, cancellationToken);

        var userTheme = user.UserTheme.FirstOrDefault(t => t.Id == request.ThemeId);
        if (userTheme is null) throw new Exception($"Theme {request.ThemeId} not found.");
        
        if (!userTheme.IsBought) throw new Exception($"Theme {request.ThemeId} not bought.");
        
        foreach (var theme in user.UserTheme)
        {
            theme.IsSelected = false;
        }
        
        userTheme.IsSelected = true;

        await _userRepository.UpdateUser(user, cancellationToken);

        return userTheme;
    }
}