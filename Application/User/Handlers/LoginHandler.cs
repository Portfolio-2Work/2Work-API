using _2Work_API.Application.User.Requests;
using _2Work_API.Application.User.Results;
using _2Work_API.Common.Base;
using _2Work_API.Entities;
using _2Work_API.Interfaces.Providers.Auth;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace _2Work_API.Application.User.Handlers
{
    public class LoginHandler(IAuthenticate authenticate, DBContext db) : IRequestHandler<LoginRequest, ObjectResponse<LoginResult>>
    {
        public async Task<ObjectResponse<LoginResult>> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            ObjectResponse<LoginResult> result = new();

            TB_User? usuario = db.TB_User.FirstOrDefault(item => item.Email.ToUpper() == request.Email.ToUpper());

            if (usuario is null)
            {
                result.ErrorNotification.AddMessage("Usuário não existe");
                return result;
            }

            if (!await authenticate.AuthenticateUser(usuario.Email, request.Password, cancellationToken))
            {
                result.ErrorNotification.AddMessage("E-mail ou senha incorretos");
                return result;
            }

            string? nome_empresa = await (from a in db.TB_User_x_Empresa
                                          join b in db.TB_Empresa on a.ID_TB_Empresa equals b.ID
                                          where a.ID_TB_User == usuario.ID
                                          select b.NM_Empresa)
                                          .FirstOrDefaultAsync(cancellationToken);

            result.Data = new LoginResult()
            {
                NM_Usuario = usuario.NM_User,
                NM_Empresa = nome_empresa ?? "",
                Token = authenticate.GenerateToken(usuario.ID)
            };

            return result;
        }
    }
}
