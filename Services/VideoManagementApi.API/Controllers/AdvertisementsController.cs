using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VideoManagementApi.API.ViewModels.Requests;
using VideoManagementApi.Application.Features.AdvertisementFeatures.Commands;
using VideoManagementApi.Application.Features.AdvertisementFeatures.Queries;
using VideoManagementApi.Domain.Common;
using VideoManagementApi.Domain.Entities;
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
        return Ok(await _mediator.Send(query));
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(IResult<List<Advertisement>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllAdvertisementsQuery();
        return Ok(await _mediator.Send(query));
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(IResult<List<Advertisement>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromForm]IFormFile file,[FromBody]CreateAdvertisementRequest request)
    {
        var command = _mapper.Map<CreateAdvertisementCommand>(request);
        command.File = file;
        return Ok(await _mediator.Send(command));
    }
    
    [HttpPut]
    [ProducesResponseType(typeof(IResult<List<Advertisement>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update([FromForm]IFormFile file,[FromBody]UpdateAdvertisementRequest request)
    {
        var command = _mapper.Map<UpdateAdvertisementCommand>(request);
        command.File = file;
        return Ok(await _mediator.Send(command));
    }
}