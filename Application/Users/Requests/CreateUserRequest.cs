using _2Work_API.Common.DTO.Empresa;
using _2Work_API.Common.DTO.Users;

namespace _2Work_API.Application.Users.Requests
{
    public class CreateUserRequest
    {
        public UserDTO User { get; set; }
        public EmpresaDTO Empresa { get; set; }
    }
}
