using _2Work_API.Application.User.Commands;
using _2Work_API.Common.Providers;
using _2Work_API.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace _2Work_API.Application.User.Validators
{
    public partial class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        private static readonly Regex _emailRgx = generateEmailRgx();
        private static readonly Regex _senhaRegex = generateSenhaRgx();

        public CreateUserValidator(DBContext db)
        {
            RuleFor(x => x).CustomAsync(async (values, context, ct) =>
            {
                //Usuario
                string email = values.User.Email;
                string password = values.User.Password;
                string nome = values.User.NM_User;

                if (nome.Length < 3)
                {
                    context.AddFailure("Nome deve ter pelo menos 3 caracteres");
                }

                if (!_senhaRegex.IsMatch(password))
                {
                    context.AddFailure("Senha informada deve conter pelo menos 1 letra maíscula, 1 caracter especial, 1 número e 8 caracteres a 30 caracteres");
                }

                if (!_emailRgx.IsMatch(email))
                {
                    context.AddFailure("E-mail informado é inválido");
                }
                else
                {
                    TB_User? usuarioByEmail = await (from a in db.TB_User
                                                     where a.Email.ToUpper() == email.ToUpper()
                                                     select a).FirstOrDefaultAsync(ct);

                    if (usuarioByEmail is not null)
                    {
                        context.AddFailure("Já existe um usuário cadastrado com este e-mail");
                    }
                }

                string cnpj = Regex.Replace(values.Empresa.CNPJ, "[^.0-9]", "");

                if (!CnpjValidator.ValidarCnpj(cnpj))
                {
                    context.AddFailure("Já existe um usuário cadastrado com este e-mail");
                }
                else
                {
                    TB_Empresa? empresabyCnpj = await (from a in db.TB_Empresa
                                                       where a.CNPJ == cnpj
                                                       select a).FirstOrDefaultAsync(ct);

                    if (empresabyCnpj is not null)
                    {
                        context.AddFailure("Já existe uma empresa cadastrada com este CNPJ");
                    }
                }

                string nome_empresa = values.Empresa.NM_Empresa;

                if (nome_empresa.Length < 3)
                {
                    context.AddFailure("Nome da empresa deve ter pelo menos 3 caracteres");
                }
            });
        }

        [GeneratedRegex("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[#$@!%&*?])[A-Za-z\\d#$@!%&*?]{8,30}$")]
        private static partial Regex generateSenhaRgx();

        [GeneratedRegex("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$")]
        private static partial Regex generateEmailRgx();
    }
}
