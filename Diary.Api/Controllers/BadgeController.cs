namespace Diary.Api.Controllers;

using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Authorize]
[Route("[controller]")]
public class BadgeController : ControllerBase
{
    private readonly IMediator _mediator;
    public BadgeController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("badges")]
    public async Task<IActionResult> GetBadges()
    {
        var badges = await _mediator.Send(new GetBadgesQuery());

        return Ok(badges);
    }
}