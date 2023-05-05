using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoManagementApi.API.ViewModels.Requests;
using VideoManagementApi.Application.Features.SeoFeatures.Commands;
using VideoManagementApi.Application.Features.SeoFeatures.Queries;
using VideoManagementApi.Application.Features.UserFeatures;
using VideoManagementApi.Domain.Common;
using VideoManagementApi.Domain.Entities;
using IResult = VideoManagementApi.Domain.Common.IResult;

namespace VideoManagementApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IResult<User>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetUserByIdQuery() { Id = id};
            var result = await _mediator.Send(query);
            if (result.Succeeded && result.Data != null)
                return Ok(result);
            if (result.Data == null)
                return NotFound(result);
            return BadRequest(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(IResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create(CreateUserCommand request)
        {
            var result = await _mediator.Send(request);
            if (result.Succeeded)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
