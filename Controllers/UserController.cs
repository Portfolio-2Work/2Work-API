using _2Work_API.Application.User.Commands;
using _2Work_API.Application.User.Requests;
using _2Work_API.Application.User.Results;
using _2Work_API.Common.Base;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _2Work_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase //: ApiController
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ObjectResponse<bool>> Create([FromBody] CreateUserCommand request) => await _mediator.Send(request);

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ObjectResponse<LoginResult>> Login([FromBody] LoginRequest request)
        {
            request.Token = HttpContext.Request.Headers["Bearer"];

            return await _mediator.Send(request);
        }

        [HttpGet("teste")]
        [Authorize]
        public async Task<string> Teste([FromQuery] string id)
        {
            return id;
        }
    }
}
