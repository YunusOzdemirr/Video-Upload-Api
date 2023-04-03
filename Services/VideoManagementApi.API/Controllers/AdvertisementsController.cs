using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VideoManagementApi.Application.Features.AdvertisementFeatures.Commands;
using VideoManagementApi.Application.Features.AdvertisementFeatures.Queries;
using VideoManagementApi.Domain.Common;
using VideoManagementApi.Domain.Entities;
using IResult = VideoManagementApi.Domain.Common.IResult;

namespace VideoManagementApi.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class AdvertisementsController : Controller
{
    private IMediator _mediator;

    public AdvertisementsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(IResult<Advertisement>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var query = new GetAdvertisementQuery() { Id = id };
        return Ok(await _mediator.Send(query));
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(IResult<List<Advertisement>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(GetAllAdvertisementsQuery query)
    {
        return Ok(await _mediator.Send(query));
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(IResult<List<Advertisement>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(CreateAdvertisementCommand command)
    {
        return Ok(await _mediator.Send(command));
    }
    
    [HttpPut]
    [ProducesResponseType(typeof(IResult<List<Advertisement>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(UpdateAdvertisementCommand command)
    {
        return Ok(await _mediator.Send(command));
    }
}