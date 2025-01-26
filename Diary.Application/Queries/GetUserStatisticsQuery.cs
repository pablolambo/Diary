namespace Diary.Application.Queries;

using Domain.Interfaces;
using DTOs;
using MediatR;

public sealed record GetUserStatisticsQuery(string UserId) : IRequest<UserStatisticsDto>;

public class GetUserStatisticsQueryHandler : IRequestHandler<GetUserStatisticsQuery, UserStatisticsDto>
{
    private readonly IUserRepository _userRepository;

    public GetUserStatisticsQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserStatisticsDto> Handle(GetUserStatisticsQuery request, CancellationToken cancellationToken)
    {
        var statisticsEntity = await _userRepository.GetUserStatistics(request.UserId, cancellationToken);

        var userStatisticsDto = UserStatisticsDto.ToDto(statisticsEntity);

        return userStatisticsDto;
    }
}