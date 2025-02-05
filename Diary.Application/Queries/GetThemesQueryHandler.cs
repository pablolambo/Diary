namespace Diary.Application.Queries;

using Domain.Interfaces;
using Domain.Models;
using MediatR;

public sealed record GetThemesQuery : IRequest<List<UserTheme>>
{
    public string UserId { get; set; }
}
public class GetThemesQueryHandler : IRequestHandler<GetThemesQuery, List<UserTheme>>
{
    private readonly IUserRepository _userRepository;

    public GetThemesQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<List<UserTheme>> Handle(GetThemesQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserById(request.UserId, cancellationToken);
        
        if (user.UserTheme == null || user.UserTheme.Count == 0)
        {
            await _userRepository.SeedThemes(request.UserId, cancellationToken);
        }

        return user.UserTheme!;
    }
}