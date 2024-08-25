using _2Work_API.Application.User.Validators;

namespace _2Work_API.Config
{
    public static class ValidatorsConfig
    {
        public static void AddValidators(this IServiceCollection services)
        {
            services.AddScoped<CreateUserValidator>();
        }
    }
}
