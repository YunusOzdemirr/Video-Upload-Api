using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VideoManagementApi.Application.Features.VideoFeatures.Commands;
using VideoManagementApi.Application.Features.VideoFeatures.Queries;
using VideoManagementApi.Domain.Entities;

namespace VideoManagementApi.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VideoController : Controller
{
    private IMediator _mediator;

    public VideoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("get")]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var result = await _mediator.Send(new GetVideosQuery());
        if ((result?.Data as List<Video>).Count > 0)
            return Ok(result);
        return NotFound(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromForm]CreateVideoCommand command)
    {
        var result = await _mediator.Send(command);
        if (!result.Succeeded)
            return BadRequest(result);
        return Ok(result);
    }
    
    [HttpPut]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update(UpdateVideoCommand command)
    {
        var result = await _mediator.Send(command);
        if (!result.Succeeded)
            return BadRequest(result);
        return Ok(result);
    }
}