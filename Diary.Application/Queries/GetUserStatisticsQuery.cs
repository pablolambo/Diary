namespace Diary.Application.Queries;

using Domain.Interfaces;
using DTOs;
using MediatR;

public sealed record GetUserStatisticsQuery(string UserId) : IRequest<UserStatistics>;

public class GetUserStatisticsQueryHandler : IRequestHandler<GetUserStatisticsQuery, UserStatistics>
{
    private readonly IUserRepository _userRepository;

    public GetUserStatisticsQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserStatistics> Handle(GetUserStatisticsQuery request, CancellationToken cancellationToken)
    {
        var statisticsEntity = await _userRepository.GetUserStatistics(request.UserId, cancellationToken);

        var userStatisticsDto = UserStatistics.ToDto(statisticsEntity);

        return userStatisticsDto;
    }
}