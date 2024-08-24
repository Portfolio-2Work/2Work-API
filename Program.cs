
using _2Work_API.Application.User.Validators;
using _2Work_API.Common.Base;
using _2Work_API.Common.Providers;
using _2Work_API.Common.Repositories;
using _2Work_API.Common.UnitOfWork;
using _2Work_API.Entities;
using _2Work_API.Interfaces.Providers;
using _2Work_API.Interfaces.Repositories;
using _2Work_API.Interfaces.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace _2Work_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers()
                            .AddJsonOptions(options =>
                            {
                                options.JsonSerializerOptions.PropertyNamingPolicy = null;
                            });


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddMediatR(c => c.RegisterServicesFromAssemblyContaining<Program>());

            builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IUser_x_EmpresaRepository, User_x_EmpresaRepository>();
            builder.Services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            builder.Services.AddScoped<CreateUserValidator>();


            builder.Services.AddHttpContextAccessor();

            string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<DBContext>(options => options.UseSqlServer(connectionString), ServiceLifetime.Scoped);


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<CustomMiddleware>();
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
