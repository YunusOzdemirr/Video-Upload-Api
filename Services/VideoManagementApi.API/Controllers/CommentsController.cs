using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VideoManagementApi.API.ViewModels.Requests;
using VideoManagementApi.Application.Features.CommentFeatures.Commands;
using VideoManagementApi.Application.Features.CommentFeatures.Queries;
using VideoManagementApi.Application.Interfaces.Services;
using VideoManagementApi.Domain.Common;
using VideoManagementApi.Domain.Entities;
using IResult = VideoManagementApi.Domain.Common.IResult;

namespace VideoManagementApi.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentsController : Controller
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly IClaimProvider _provider;

    public CommentsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(IResult<Comment>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(int id)
    {
        var query = new GetCommentQuery() { Id = id };
        var result = await _mediator.Send(query);
        return Ok(Result.SuccessAsync(result));
    }

    [HttpGet("{videoId}")]
    [ProducesResponseType(typeof(IResult<List<Comment>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByVideoId(int videoId)
    {
        var query = new GetCommentsQuery() { VideoId = videoId };
        var result = await _mediator.Send(query);
        return Ok(Result.SuccessAsync(result));
    }

    [HttpPost]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status200OK)]
    public async Task<IActionResult> Create(CreateCommentRequest request)
    {
        var command = _mapper.Map<CreateCommentCommand>(request);
        command.IpAddress = await _provider.GetIpAddress();
        var result = await _mediator.Send(command);
        return Ok(Result.SuccessAsync(result));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteCommentCommand() { Id = id };
        var result = await _mediator.Send(command);
        if (result.Succeeded)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpPut]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status200OK)]
    public async Task<IActionResult> Approve(ApproveCommentRequest request)
    {
        var command = _mapper.Map<ApproveCommentCommand>(request);
        command.IpAddress = await _provider.GetIpAddress();
        var result = await _mediator.Send(command);
        return Ok(Result.SuccessAsync(result));
    }
}