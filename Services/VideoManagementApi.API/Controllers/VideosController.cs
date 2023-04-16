using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VideoManagementApi.API.Providers;
using VideoManagementApi.API.ViewModels.Requests;
using VideoManagementApi.Application.Features.VideoFeatures.Commands;
using VideoManagementApi.Application.Features.VideoFeatures.Queries;
using VideoManagementApi.Application.Interfaces.Services;
using VideoManagementApi.Domain.Common;
using VideoManagementApi.Domain.Entities;
using IResult = VideoManagementApi.Domain.Common.IResult;

namespace VideoManagementApi.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VideosController : Controller
{
    private IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly IClaimProvider _provider;

    public VideosController(IMediator mediator, IMapper mapper, IClaimProvider provider)
    {
        _mediator = mediator;
        _mapper = mapper;
        _provider = provider;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(IResult<Video>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var result = await _mediator.Send(new GetVideoQuery() { Id = id });
        if (result?.Data != null)
            return Ok(result);
        return NotFound(result);
    }

    [HttpGet]
    [ProducesResponseType(typeof(IResult<List<Video>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(bool? isActive)
    {
        var result = await _mediator.Send(new GetVideosQuery() { IsActive = isActive });
        if ((result?.Data as List<Video>).Count > 0)
            return Ok(result);
        return NotFound(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status400BadRequest)]
    [RequestSizeLimit(long.MaxValue)]
    public async Task<IActionResult> Create([FromForm] CreateVideoRequest request)
    {
        var command = new CreateVideoCommand()
        {
            Title = "Video Bilgileri Bekleniyor.",
            Description = "Upload Başarılı 2. Adım Bekleniyor",
            File = request.File,
            IpAddress = await _provider.GetIpAddress()
        };
        var result = await _mediator.Send(command);
        if (result.Succeeded)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpPut("ContentUpdate/{videoId}")]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateUpload([FromForm] CreateVideoRequest request, int videoId)
    {
        var command = new UpdateVideoContentCommand() { File = request.File, Id = videoId };
        var result = await _mediator.Send(command);
        if (result.Succeeded)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpPut]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update(UpdateVideoRequest request)
    {
        var command = _mapper.Map<UpdateVideoCommand>(request);
        command.IpAddress = await _provider.GetIpAddress();
        var result = await _mediator.Send(command);
        if (result.Succeeded)
            return Ok(result);
        return BadRequest(result);
    }
}