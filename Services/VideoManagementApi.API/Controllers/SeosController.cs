using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VideoManagementApi.Application.Features.SeoFeatures.Commands;
using VideoManagementApi.Application.Features.SeoFeatures.Queries;
using VideoManagementApi.Domain.Common;
using VideoManagementApi.Domain.Entities;
using IResult = VideoManagementApi.Domain.Common.IResult;

namespace VideoManagementApi.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class SeosController : Controller
{
    private readonly IMediator _mediator;

    public SeosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{videoId}")]
    [ProducesResponseType(typeof(IResult<List<Seo>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(int videoId)
    {
        var query = new GetSeosByVideoIdQuery() { VideoId = videoId };
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status200OK)]
    public async Task<IActionResult> Create(CreateSeoCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status200OK)]
    public async Task<IActionResult> Update(UpdateSeoCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}