using _2Work_API.Application.User.Commands;
using _2Work_API.Common.Base;
using MediatR;
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
        public async Task<ObjectResponse<bool>> Create([FromBody] CreateUserCommand request) => await _mediator.Send(request);
    }
}
