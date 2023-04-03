using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VideoManagementApi.Application.Features.CommentFeatures.Commands;
using VideoManagementApi.Application.Features.CommentFeatures.Queries;
using VideoManagementApi.Domain.Common;
using VideoManagementApi.Domain.Entities;
using IResult = VideoManagementApi.Domain.Common.IResult;

namespace VideoManagementApi.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class CommentsController : Controller
{
    private readonly IMediator _mediator;

    public CommentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(IResult<Comment>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(int id)
    {
        var query = new GetCommentQuery() { Id = id };
        var result = await _mediator.Send(query);
        return Ok(Result.SuccessAsync(result));
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(IResult<List<Comment>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get()
    {
        var query = new GetCommentsQuery();
        var result = await _mediator.Send(query);
        return Ok(Result.SuccessAsync(result));
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status200OK)]
    public async Task<IActionResult> Create(CreateCommentCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(Result.SuccessAsync(result));
    }
    
    [HttpPut]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status200OK)]
    public async Task<IActionResult> Approve(ApproveCommentCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(Result.SuccessAsync(result));
    }
}