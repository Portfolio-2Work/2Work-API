using _2Work_API.Common.Repositories;
using _2Work_API.Common.UnitOfWork;
using _2Work_API.Interfaces.Repositories;
using _2Work_API.Interfaces.UnitOfWork;

namespace _2Work_API.Config
{
    public static class RepositoriesConfig
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUser_x_EmpresaRepository, User_x_EmpresaRepository>();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
