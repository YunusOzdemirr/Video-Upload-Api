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
   [ProducesResponseType(typeof(IResult<List<Category>>),StatusCodes.Status200OK)]
   public async Task<IActionResult> Get()
   {
      var query = new GetCategoriesQuery();
      var result = await _mediator.Send(query);
      return Ok(result);
   }
   [HttpPost]
   [ProducesResponseType(typeof(IResult),StatusCodes.Status200OK)]
   public async Task<IActionResult> Create([FromForm]IFormFile file,[FromBody]CreateCategoryRequest request)
   {
      var command = _mapper.Map<CreateCategoryCommand>(request);
      command.File = file;
      var result = await _mediator.Send(command);
      return Ok(result);
   }
   [HttpPut]
   [ProducesResponseType(typeof(IResult),StatusCodes.Status200OK)]
   public async Task<IActionResult> Update([FromForm]IFormFile file,[FromBody]UpdateCategoryRequest request)
   {
      var command = _mapper.Map<UpdateCategoryCommand>(request);
      command.File = file;
      var result = await _mediator.Send(command);
      return Ok(result);
   }
}