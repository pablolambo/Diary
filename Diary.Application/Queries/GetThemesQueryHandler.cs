namespace Diary.Application.Queries;

using Domain.Interfaces;
using DTOs;
using MediatR;

public sealed record GetThemesQuery : IRequest<List<ThemeDto>>;

public class GetThemesQueryHandler : IRequestHandler<GetThemesQuery, List<ThemeDto>>
{
    private readonly IThemesRepository _themesRepository;

    public GetThemesQueryHandler(IThemesRepository themesRepository)
    {
        _themesRepository = themesRepository;
    }

    public async Task<List<ThemeDto>> Handle(GetThemesQuery request, CancellationToken cancellationToken)
    { 
        var themesEntity = await _themesRepository.GetThemesAsync();
        
        return ThemeDto.ListToDto(themesEntity);
    }
}