using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VideoManagementApi.API.ViewModels.Requests;
using VideoManagementApi.API.ViewModels.Responses;
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
    [ProducesResponseType(typeof(IResult<List<LikeResponse>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(int videoId)
    {
        var query = new GetLikesQuery() { VideoId = videoId };
        var result = await _mediator.Send(query);
        if (result.Succeeded && result.Data != null)
        {
            var response = _mapper.Map<List<LikeResponse>>(result.Data);
            return Ok(response);
        }
        if (result.Data == null)
            return NotFound(result);
        return BadRequest(result);
    }

    [HttpPost("{videoId}/{isLiked}")]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status200OK)]
    public async Task<IActionResult> Create(int videoId, bool isLiked)
    {
        var command = new CreateOrUpdateLikeCommand() { VideoId = videoId, IsLiked = isLiked };
        command.IpAddress = await _provider.GetIpAddress();
        var result = await _mediator.Send(command);
        if (result.Succeeded)
            return Ok(result);
        return BadRequest(result);
    }
}