using System.Net;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using VideoManagementApi.Application.Features.CategoryFeatures.Commands;
using VideoManagementApi.Application.Features.CategoryFeatures.Queries;
using VideoManagementApi.Domain.Common;
using VideoManagementApi.Domain.Entities;
using IResult = VideoManagementApi.Domain.Common.IResult;

namespace VideoManagementApi.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class CategoriesController : Controller
{
   private readonly IMediator _mediator;

   public CategoriesController(IMediator mediator)
   {
      _mediator = mediator;
   }

   [HttpGet]
   [ProducesResponseType(typeof(IResult<List<Category>>),StatusCodes.Status200OK)]
   public async Task<IActionResult> Get()
   {
      var query = new GetCategoriesQuery();
      var result = await _mediator.Send(query);
      return Ok(result);
   }
   [HttpPost]
   [ProducesResponseType(typeof(IResult),StatusCodes.Status200OK)]
   public async Task<IActionResult> Create(CreateCategoryCommand command)
   {
      var result = await _mediator.Send(command);
      return Ok(result);
   }
   [HttpPut]
   [ProducesResponseType(typeof(IResult),StatusCodes.Status200OK)]
   public async Task<IActionResult> Update(UpdateCategoryCommand command)
   {
      var result = await _mediator.Send(command);
      return Ok(result);
   }
}