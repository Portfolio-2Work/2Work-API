using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace _2Work_API.Common.Base
{
    [ApiController]
    [Produces("application/json")]
    public class ApiController : ControllerBase
    {
        protected IMediator Mediatr => _mediatr;
        public IMediator _mediatr
        {
            get
            {
                return HttpContext.RequestServices.GetService<IMediator>();
            }
        }
    }
}
