using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VideoManagementApi.API.Providers;
using VideoManagementApi.API.ViewModels.Requests;
using VideoManagementApi.Application.Features.SeoFeatures.Commands;
using VideoManagementApi.Application.Features.SeoFeatures.Queries;
using VideoManagementApi.Application.Interfaces.Services;
using VideoManagementApi.Domain.Common;
using VideoManagementApi.Domain.Entities;
using IResult = VideoManagementApi.Domain.Common.IResult;

namespace VideoManagementApi.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SeosController : Controller
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public SeosController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
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
    public async Task<IActionResult> Create(CreateSeoRequest request)
    {
        var command = _mapper.Map<CreateSeoCommand>(request);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status200OK)]
    public async Task<IActionResult> Update(UpdateSeoRequest request)
    {
        var command = _mapper.Map<UpdateSeoCommand>(request);
        var result = await _mediator.Send(command);
        return Ok(result);
    }
    
    [HttpDelete]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status200OK)]
    public async Task<IActionResult> Update(DeleteSeoByVideoIdCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
    
}