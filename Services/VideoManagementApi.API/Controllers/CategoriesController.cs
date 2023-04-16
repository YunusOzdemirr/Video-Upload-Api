using System.Net;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using VideoManagementApi.API.ViewModels.Requests;
using VideoManagementApi.Application.Features.CategoryFeatures.Commands;
using VideoManagementApi.Application.Features.CategoryFeatures.Queries;
using VideoManagementApi.Domain.Common;
using VideoManagementApi.Domain.Entities;
using IResult = VideoManagementApi.Domain.Common.IResult;

namespace VideoManagementApi.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : Controller
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public CategoriesController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IResult<List<Category>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get()
    {
        var query = new GetCategoriesQuery();
        var result = await _mediator.Send(query);
        if (result.Succeeded && result.Data != null)
            return Ok(result);
        if (result.Data == null)
            return NotFound(result);
        return BadRequest(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status200OK)]
    public async Task<IActionResult> Create([FromForm] CreateCategoryRequest request)
    {
        var command = _mapper.Map<CreateCategoryCommand>(request);
        var result = await _mediator.Send(command);
        if (result.Succeeded)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpPut]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status200OK)]
    public async Task<IActionResult> Update([FromForm] UpdateCategoryCommand command)
    {
        var result = await _mediator.Send(command);
        if (result.Succeeded)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpPut("AddCount/{id}")]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddCount(int id)
    {
        var command = new AddCountCategoryCommand() { Id = id };
        var result = await _mediator.Send(command);
        if (result.Succeeded)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpDelete]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteCategoryCommand() { Id = id };
        var result = await _mediator.Send(command);
        if (result.Succeeded)
            return Ok(result);
        return BadRequest(result);
    }
}