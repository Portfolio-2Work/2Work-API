using _2Work_API.Application.User.Commands;
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
        public async Task<bool> Create([FromBody] CreateUserCommand request) => await _mediator.Send(request);
    }
}
