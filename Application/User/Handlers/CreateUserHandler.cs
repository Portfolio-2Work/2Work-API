using _2Work_API.Application.User.Commands;
using _2Work_API.Application.User.Validators;
using _2Work_API.Common.Base;
using _2Work_API.Common.Enums;
using _2Work_API.Common.Structs;
using _2Work_API.Entities;
using _2Work_API.Interfaces.Providers;
using _2Work_API.Interfaces.Repositories;
using _2Work_API.Interfaces.UnitOfWork;
using MediatR;

namespace _2Work_API.Application.Users.Actions;

public class CreateUserHandler(
    IPasswordHasher passwordHasher,
    IUnitOfWork unitOfWork,
    IUserRepository userRepository,
    IEmpresaRepository empresaRepository,
    IUser_x_EmpresaRepository user_X_EmpresaRepository,
    CreateUserValidator validator
  ) : IRequestHandler<CreateUserCommand, ObjectResponse<bool>>
{
    public async Task<ObjectResponse<bool>> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        ObjectResponse<bool> result = new();

        if (!await IsValid(command, result, cancellationToken))
        {
            return result;
        }

        await unitOfWork.BeginTransaction(cancellationToken);

        string hash = passwordHasher.Hash(command.User.Password);

        TB_User? usuario = await userRepository.Add(new()
        {
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            NM_User = command.User.NM_User,
            Email = command.User.Email,
            ST_Record = StRecord.Active,
            TP_User = TpUser.Admin,
            Password = hash

        }, cancellationToken);

        TB_Empresa? empresa = await empresaRepository.Add(new()
        {
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            NM_Empresa = command.Empresa.NM_Empresa,
            ST_Record = StRecord.Active,
            CNPJ = command.Empresa.CNPJ
        }, cancellationToken);

        if (usuario is null || empresa is null)
        {
            await unitOfWork.Rollback(cancellationToken);
            return result;
        }

        await user_X_EmpresaRepository.Add(new()
        {
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            ID_TB_Empresa = empresa.ID,
            ID_TB_User = usuario.ID,
        });

        result.Data = await unitOfWork.Commit(cancellationToken) == null;

        return result;
    }

    private async Task<bool> IsValid(CreateUserCommand command, ObjectResponse<bool> response, CancellationToken ct)
    {
        var validationResult = await validator.ValidateAsync(command, ct);

        if (validationResult.Errors.Count > 0)
        {
            response.ErrorNotification.AddMessage(validationResult);
        }

        return validationResult.IsValid;
    }
}
