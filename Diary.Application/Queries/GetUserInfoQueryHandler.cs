namespace Diary.Application.Queries;

using Domain.Entities;
using Domain.Interfaces;
using MediatR;

public sealed record GetUserInfoQuery(string UserId) : IRequest<DiaryUserEntity>;

public class GetUserInfoQueryHandler : IRequestHandler<GetUserInfoQuery, DiaryUserEntity>
{
    private readonly IUserRepository _userRepository;

    public GetUserInfoQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<DiaryUserEntity> Handle(GetUserInfoQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserById(request.UserId, cancellationToken);
        
        if (user == null)
            throw new Exception($"User with id {request.UserId} not found");
     
        return user;
    }
}