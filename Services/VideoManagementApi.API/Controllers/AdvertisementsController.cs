using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VideoManagementApi.API.ViewModels.Requests;
using VideoManagementApi.Application.Features.AdvertisementFeatures.Commands;
using VideoManagementApi.Application.Features.AdvertisementFeatures.Queries;
using VideoManagementApi.Domain.Common;
using VideoManagementApi.Domain.Entities;
using VideoManagementApi.Domain.Enums;
using IResult = VideoManagementApi.Domain.Common.IResult;

namespace VideoManagementApi.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdvertisementsController : Controller
{
    private IMediator _mediator;
    private readonly IMapper _mapper;

    public AdvertisementsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(IResult<Advertisement>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var query = new GetAdvertisementQuery() { Id = id };

        var result = await _mediator.Send(query);
        if (result.Succeeded && result.Data != null)
            return Ok(result);
        if (result.Data == null)
            return NotFound();
        return BadRequest();
    }

    [HttpGet("{isActive}")]
    [ProducesResponseType(typeof(IResult<List<Advertisement>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAll(bool? isActive)
    {
        var query = new GetAllAdvertisementsQuery() { IsActive = isActive };
        var result = await _mediator.Send(query);
        if (result.Succeeded && result.Data != null)
            return Ok(result);
        if (result.Data == null)
            return NotFound();
        return BadRequest();
    }

    [HttpPost]
    [ProducesResponseType(typeof(IResult<int>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromForm] CreateAdvertisementRequest request)
    {
        var command = _mapper.Map<CreateAdvertisementCommand>(request);
        var result = await _mediator.Send(command);
        if (result.Succeeded)
            return Ok(result);
        return BadRequest();
    }

    [HttpPut("UpdateContent")]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateContent([FromForm] UpdateAdvertisementContentCommand command)
    {
        var result = await _mediator.Send(command);
        if (result.Succeeded)
            return Ok(result);
        return BadRequest();
    }

    [HttpPut]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update([FromBody] UpdateAdvertisementRequest request)
    {
        var command = _mapper.Map<UpdateAdvertisementCommand>(request);
        var result = await _mediator.Send(command);
        if (result.Succeeded && result.Data != null)
            return Ok(result);
        return BadRequest();
    }

    [HttpPut("{id}/{type}")]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddCount(int id, CountType type)
    {
        var command = new AddCountAdvertisementCommand() { Id = id, CountType = type };
        var result = await _mediator.Send(command);
        if (result.Succeeded)
            return Ok(result);
        return BadRequest();
    }

    [HttpDelete]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteAdvertisementCommand() { Id = id };
        var result = await _mediator.Send(command);
        if (result.Succeeded)
            return Ok(result);
        return BadRequest();
    }
}