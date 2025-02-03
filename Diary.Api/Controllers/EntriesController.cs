namespace Diary.Api.Controllers;

using System.Security.Claims;
using Application.Handlers.Entries;
using Application.Queries;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Authorize]
[Route("[controller]")]
public class EntriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public EntriesController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("create")]
    public async Task<IActionResult> Create(CreateEntryCommand command)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        command.UserId = userId ?? command.UserId;
        
        var (id, badgesAwarded) = await _mediator.Send(command);
        
        var response = new CreateEntryResponse
        {
            Id = id,
            BadgesAwarded = badgesAwarded
        };
        
        return CreatedAtAction(nameof(GetById), new { id }, response);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var entry = await _mediator.Send(new GetEntryByIdQuery(id));
        return entry != null ? Ok(entry) : NotFound();
    }

    [HttpPost("search")]
    public async Task<IActionResult> Get([FromBody] GetEntriesQuery query)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        query.UserId = userId ?? query.UserId;
        
        var entries = await _mediator.Send(query);
        return Ok(entries);
    }
    
    [HttpPost("favourite/{id:guid}")]
    public async Task<IActionResult> ChangeFavouriteStatus([FromRoute] Guid id)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
     
        if (userId == null)
            throw new UnauthorizedAccessException("User is not authenticated.");
        
        var entries = await _mediator.Send(new FavouriteEntryCommand(id, userId));
        return Ok(entries);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, UpdateEntryCommand command)
    {
        if (id == Guid.Empty) return BadRequest();
        
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
     
        if (userId == null)
            throw new UnauthorizedAccessException("User is not authenticated.");

        command.EntryId = id;
        command.UserId = userId;
        
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        if (id == Guid.Empty) return BadRequest();

        await _mediator.Send(new DeleteEntryCommand(id));
        return NoContent();
    }
}