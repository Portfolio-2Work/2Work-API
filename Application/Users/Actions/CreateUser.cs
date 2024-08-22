using _2Work_API.Application.Users.Requests;
using _2Work_API.Common.Enums;
using _2Work_API.Common.Structs;
using _2Work_API.Interfaces.Providers;
using MediatR;

namespace _2Work_API.Application.Users.Actions;

public class CreateUserCommand(CreateUserRequest request) : IRequest<bool>
{
    public CreateUserRequest Request { get; } = request;
}

public class CreateUserHandler(IPasswordHasher passwordHasher) : IRequestHandler<CreateUserCommand, bool>
{
    private readonly IPasswordHasher _passwordHasher = passwordHasher;

    public async Task<bool> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        string hash = _passwordHasher.Hash(command.Request.User.Password);

        command.Request.User.TP_User = TpUser.Admin;
        command.Request.User.ST_Record = StRecord.Active;
        command.Request.User.Password = hash;

        command.Request.Empresa.ST_Record = StRecord.Active;


        return await Task.FromResult(true);
    }
}
