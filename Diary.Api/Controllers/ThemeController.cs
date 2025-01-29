namespace Diary.Api.Controllers;

using System.Security.Claims;
using Application.Handlers.Themes;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Authorize]
[Route("[controller]")]
public class ThemeController : ControllerBase
{
    private readonly IMediator _mediator;
    public ThemeController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("unlock/{themeId:guid}")]
    public async Task<IActionResult> UnlockTheme(Guid themeId)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        
        if (userId == null)
            throw new UnauthorizedAccessException("User is not authenticated.");
        
        await _mediator.Send(new BuyThemeCommand(themeId, userId));

        return Ok();
    }
    
    [HttpGet("themes")]
    public async Task<IActionResult> GetThemes()
    {
        var themes = await _mediator.Send(new GetThemesQuery());

        return Ok(themes);
    }
    
    [HttpGet("set/{themeId:guid}")]
    public async Task<IActionResult> SetTheme([FromRoute] Guid themeId)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        
        if (userId == null)
            throw new UnauthorizedAccessException("User is not authenticated.");
        
        var theme = await _mediator.Send(new GetThemeQuery(userId, themeId));

        return Ok(theme);
    }
}