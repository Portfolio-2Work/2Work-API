namespace _2Work_API.Interfaces.Providers
{
    public interface IPasswordHasher : IService
    {
        string Hash(string password);
        bool Verify(string passwordHash, string password);
    }
}
