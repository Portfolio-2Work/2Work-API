using _2Work_API.Common.Providers;
using _2Work_API.Common.Providers.Auth;
using _2Work_API.Interfaces.Providers;
using _2Work_API.Interfaces.Providers.Auth;

namespace _2Work_API.Config
{
    public static class ProvidersConfig
    {
        public static void AddProviders(this IServiceCollection services)
        {
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IAuthenticate, Authenticate>();
        }
    }
}
