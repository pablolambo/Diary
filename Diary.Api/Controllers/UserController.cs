﻿namespace Diary.Api.Controllers;

using System.Security.Claims;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Authorize]
[Route("[controller]")]
public class UserController  : ControllerBase
{
    private readonly IMediator _mediator;
    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("statistics")]
    public async Task<IActionResult> GetStatistics()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
        if (userId == null)
            throw new UnauthorizedAccessException("User is not authenticated.");
        
        var stats = await _mediator.Send(new GetUserStatisticsQuery(userId));
        return Ok(stats);
    }
    
    [HttpGet("me")]
    public async Task<IActionResult> UserInfo()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
        if (userId == null)
            throw new UnauthorizedAccessException("User is not authenticated.");
        
        var user = await _mediator.Send(new GetUserInfoQuery(userId));
        return Ok(user);
    }
}