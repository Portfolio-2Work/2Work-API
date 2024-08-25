using _2Work_API.Application.User.Results;
using _2Work_API.Common.Base;
using MediatR;

namespace _2Work_API.Application.User.Requests
{
    public class LoginRequest : IRequest<ObjectResponse<LoginResult>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
