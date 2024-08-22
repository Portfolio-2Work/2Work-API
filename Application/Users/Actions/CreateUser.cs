using _2Work_API.Application.Users.Requests;
using _2Work_API.Common.Enums;
using _2Work_API.Common.Structs;
using _2Work_API.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace _2Work_API.Application.Users.Actions;

public class CreateUserCommand(CreateUserRequest request) : IRequest<bool>
{
    public CreateUserRequest Request { get; } = request;
}

public class CreateUserHandler : IRequestHandler<CreateUserCommand, bool>
{
    private readonly DBContext _dbContext;

    public CreateUserHandler(DBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        command.Request.TP_User = TpUser.Admin;
        command.Request.ST_Record = StRecord.Active;

        var aaaaa = await (from a in _dbContext.Users select a).FirstOrDefaultAsync(cancellationToken);

        return await Task.FromResult(true);
    }
}
