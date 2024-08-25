using _2Work_API.Common.Providers;
using _2Work_API.Interfaces.Providers;

namespace _2Work_API.Config
{
    public static class ProvidersConfig
    {
        public static void AddProviders(this IServiceCollection services)
        {
            services.AddScoped<IPasswordHasher, PasswordHasher>();
        }
    }
}
