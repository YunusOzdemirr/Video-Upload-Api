using MediatR;
using Microsoft.AspNetCore.Mvc;
using VideoManagementApi.Application.Features.ReportFeatures.Commands;
using VideoManagementApi.Application.Features.ReportFeatures.Queries;
using IResult = VideoManagementApi.Domain.Common.IResult;

namespace VideoManagementApi.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReportsController : Controller
{
    private readonly IMediator _mediator;

    public ReportsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get()
    {
        var query = new GetReportsQuery();
        var result = await _mediator.Send(query);
        if (result.Succeeded)
            return Ok(result);
        return BadRequest(result);
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IResult), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(CreateReportCommand command)
    {
        var result = await _mediator.Send(command);
        if (result.Succeeded)
            return Ok(result);
        return BadRequest(result);
    }
}