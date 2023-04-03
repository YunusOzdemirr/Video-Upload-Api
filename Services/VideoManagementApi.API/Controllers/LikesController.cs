using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VideoManagementApi.Application.Features.LikeFeatures.Commands;
using VideoManagementApi.Application.Features.LikeFeatures.Queries;
using VideoManagementApi.Domain.Common;
using VideoManagementApi.Domain.Entities;
using IResult = VideoManagementApi.Domain.Common.IResult;

namespace VideoManagementApi.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class LikesController : Controller
{
    private readonly IMediator _mediator;

    public LikesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{videoId}")]
    [ProducesResponseType(typeof(IResult<Like>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(int videoId)
    {
        var model = new GetLikesQuery() { VideoId = videoId };
        await _mediator.Send(model);
        return Ok(Result.SuccessAsync());
    }

    [HttpPost]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status200OK)]
    public async Task<IActionResult> Create(CreateOrUpdateLikeCommand command)
    {
        await _mediator.Send(command);
        return Ok(Result.SuccessAsync());
    }
}