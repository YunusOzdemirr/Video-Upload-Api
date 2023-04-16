using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VideoManagementApi.API.ViewModels.Requests;
using VideoManagementApi.Application.Features.LikeFeatures.Commands;
using VideoManagementApi.Application.Features.LikeFeatures.Queries;
using VideoManagementApi.Application.Interfaces.Services;
using VideoManagementApi.Domain.Common;
using VideoManagementApi.Domain.Entities;
using IResult = VideoManagementApi.Domain.Common.IResult;

namespace VideoManagementApi.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LikesController : Controller
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly IClaimProvider _provider;
    public LikesController(IMediator mediator, IMapper mapper, IClaimProvider provider)
    {
        _mediator = mediator;
        _mapper = mapper;
        _provider = provider;
    }

    [HttpGet("{videoId}")]
    [ProducesResponseType(typeof(IResult<Like>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(int videoId)
    {
        var model = new GetLikesQuery() { VideoId = videoId };
        await _mediator.Send(model);
        return Ok(Result.SuccessAsync());
    }

    [HttpPost("{videoId}/{isLiked}")]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status200OK)]
    public async Task<IActionResult> Create(int videoId,bool isLiked)
    {
        var command = new CreateOrUpdateLikeCommand() { VideoId = videoId,IsLiked = isLiked};
        command.IpAddress =await _provider.GetIpAddress();
        await _mediator.Send(command);
        return Ok(Result.SuccessAsync());
    }
}