using _2Work_API.Application.User.Commands;
using _2Work_API.Application.User.Requests;
using _2Work_API.Application.User.Results;
using _2Work_API.Common.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _2Work_API.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ApiController
    {
        [HttpPost]
        [AllowAnonymous]
        public async Task<ObjectResponse<bool>> Create([FromBody] CreateUserCommand request) => await Mediatr.Send(request);

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ObjectResponse<LoginResult>> Login([FromBody] LoginRequest request)
        {
            return await Mediatr.Send(request);
        }

        [HttpGet("teste")]
        [Authorize]
        public async Task<string> Teste([FromQuery] string id)
        {
            return id;
        }
    }
}
