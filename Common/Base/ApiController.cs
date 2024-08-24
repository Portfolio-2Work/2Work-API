using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace _2Work_API.Common.Base
{
    [ApiController]
    [Produces("application/json")]
    public class ApiController : ControllerBase
    {
        public readonly IMediator _mediator;

        public ApiController()
        {
            _mediator = HttpContext.RequestServices.GetService<IMediator>();
        }
    }
}
