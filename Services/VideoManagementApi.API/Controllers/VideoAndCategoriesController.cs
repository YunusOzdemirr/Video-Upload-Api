using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VideoManagementApi.Application.Features.VideoAndCategoryFeatures.Commands;
using VideoManagementApi.Application.Features.VideoAndCategoryFeatures.Queries;
using VideoManagementApi.Domain.Common;
using VideoManagementApi.Domain.Entities;
using IResult = VideoManagementApi.Domain.Common.IResult;

namespace VideoManagementApi.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VideoAndCategoriesController : Controller
{
    private readonly IMediator _mediator;

    public VideoAndCategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("GetCategories/{videoId}")]
    [ProducesResponseType(typeof(IResult<List<VideoAndCategory>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCategories(int videoId)
    {
        var query = new GetCategoriesByVideoIdQuery() { VideoId = videoId };
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("GetVideos/{categoryId}")]
    [ProducesResponseType(typeof(IResult<List<VideoAndCategory>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetVideos(int categoryId)
    {
        var query = new GetVideosByCategoryIdQuery() { CategoryId = categoryId };
        var result = await _mediator.Send(query);
        return Ok(result);
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status200OK)]
    public async Task<IActionResult> Create(CreateVideoAndCategoryCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
    
    [HttpDelete]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete(DeleteVideoAndCategoryCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}