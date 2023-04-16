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

    public CommentsController(IMediator mediator, IMapper mapper, IClaimProvider provider)
    {
        _mediator = mediator;
        _mapper = mapper;
        _provider = provider;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(IResult<Comment>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(int id)
    {
        var query = new GetCommentQuery() { Id = id };
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("GetByVideo/{videoId}")]
    [ProducesResponseType(typeof(IResult<List<Comment>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByVideoId(int videoId)
    {
        var query = new GetCommentsQuery() { VideoId = videoId };
        var result = await _mediator.Send(query);
        if (result.Succeeded)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpGet]
    [ProducesResponseType(typeof(IResult<List<Comment>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllCommentsQuery();
        var result = await _mediator.Send(query);
        if (result.Succeeded && result.Data != null)
            return Ok(result);
        if (result.Data == null)
            return NotFound(result);
        return BadRequest(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status200OK)]
    public async Task<IActionResult> Create(CreateCommentRequest request)
    {
        var command = _mapper.Map<CreateCommentCommand>(request);
        command.IpAddress = await _provider.GetIpAddress();
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
        if (result.Succeeded)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteCommentCommand() { Id = id };
        var result = await _mediator.Send(command);
        if (result.Succeeded)
            return Ok(result);
        return BadRequest(result);
    }
}