using _2Work_API.Application.Users.Actions;
using _2Work_API.Application.Users.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace _2Work_API.Controllers
{
    [Route("Users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<bool> Create([FromBody] CreateUserRequest request) => await _mediator.Send(new CreateUserCommand(request));
    }
}
