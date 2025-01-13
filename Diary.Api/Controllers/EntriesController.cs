namespace Diary.Api.Controllers;

using Application.Handlers;
using Application.Handlers.Entries;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
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
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, id);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var entry = await _mediator.Send(new GetEntryByIdQuery(id));
        return entry != null ? Ok(entry) : NotFound();
    }

    [HttpPost("search")]
    public async Task<IActionResult> Get([FromBody] GetEntriesQuery query)
    {
        var entries = await _mediator.Send(query);
        return Ok(entries);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, UpdateEntryCommand command)
    {
        if (id == Guid.Empty) return BadRequest();
        
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        if (id == Guid.Empty) return BadRequest();

        await _mediator.Send(new DeleteEntryCommand(id));
        return NoContent();
    }
}