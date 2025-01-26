namespace Diary.Application.Queries;

using Domain.Interfaces;
using DTOs;
using MediatR;

public sealed record GetBadgesQuery : IRequest<List<BadgeDto>>;

public class GetBadgesQueryHandler : IRequestHandler<GetBadgesQuery, List<BadgeDto>>
{
    private readonly IBadgeRepository _badgeRepository;

    public GetBadgesQueryHandler(IBadgeRepository badgeRepository)
    {
        _badgeRepository = badgeRepository;
    }

    public async Task<List<BadgeDto>> Handle(GetBadgesQuery request, CancellationToken cancellationToken)
    {
        var badgesEntity = await _badgeRepository.GetBadgesAsync();

        var badges = BadgeDto.FromEntities(badgesEntity);
        
        return badges;
    }
}