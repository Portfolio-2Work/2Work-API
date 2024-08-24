using _2Work_API.Common.Base;
using _2Work_API.Common.DTO.Empresa;
using _2Work_API.Common.DTO.Users;
using MediatR;

namespace _2Work_API.Application.User.Commands
{
    public class CreateUserCommand : IRequest<ObjectResponse<bool>>
    {
        public CreateUserDTO User { get; set; }
        public CreateEmpresaDTO Empresa { get; set; }
    }
}
