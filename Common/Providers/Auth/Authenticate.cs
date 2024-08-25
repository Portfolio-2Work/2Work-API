using _2Work_API.Entities;
using _2Work_API.Interfaces.Providers;
using _2Work_API.Interfaces.Providers.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace _2Work_API.Common.Providers.Auth
{
    public class Authenticate : IAuthenticate
    {
        private readonly DBContext db;
        private readonly IConfiguration configuration;
        private readonly IPasswordHasher passwordHasher;

        public Authenticate(DBContext db, IConfiguration configuration, IPasswordHasher passwordHasher)
        {
            this.db = db;
            this.configuration = configuration;
            this.passwordHasher = passwordHasher;
        }

        public string GenerateToken(Guid UserId)
        {
            TB_User? usuario = db.TB_User.Where(w => w.ID == UserId).FirstOrDefault();

            if (usuario == null)
            {
                return "";
            }

            var claims = new[]
            {
                new Claim("id", usuario.ID.ToString()),
                new Claim("email", usuario.Email),
                new Claim("tp_user", usuario.TP_User),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            string secretKey = configuration["jwt:secretKey"];

            var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.Sha256);

            var expiration = DateTime.UtcNow.AddMinutes(60);
        }

        public async Task<bool> AuthenticateUser(string email, string password, CancellationToken ct = default)
        {
            var usuario = await db.TB_User.Where(w => w.Email.ToUpper() == email.ToUpper()).FirstOrDefaultAsync(ct);

            if (usuario is null)
            {
                return false;
            }

            bool senhaValida = passwordHasher.Verify(usuario.Password, password);

            if (!senhaValida)
            {
                return false;
            }

            return true;
        }
    }
}
