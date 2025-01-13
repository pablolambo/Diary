namespace Diary.Api.Controllers;

using Application.Handlers.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class NotificationsController : ControllerBase
{
    private readonly IMediator _mediator;

    public NotificationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("daily-reminder")]
    public async Task<IActionResult> CreateAndSendNotifications(CreateAndSendNotificationsCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }
}