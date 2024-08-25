namespace _2Work_API.Interfaces.Providers.Auth
{
    public interface IAuthenticate
    {
        Task<bool> AuthenticateUser(string email, string password, CancellationToken ct = default);
        string GenerateToken(Guid UserId);
    }
}
