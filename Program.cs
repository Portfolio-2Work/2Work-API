using _2Work_API.Common.Base;
using _2Work_API.Config;
using _2Work_API.Entities;
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

            builder.Services.AddProviders();
            builder.Services.AddRepositories();
            builder.Services.AddValidators();

            builder.Services.AddHttpContextAccessor();

            string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            string? secretKey = builder.Configuration["jwt:secretKey"];

            builder.Services.AddDbContext<DBContext>(options => options.UseSqlServer(connectionString), ServiceLifetime.Scoped);

            builder.Services.AddJwt(secretKey);

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
            app.UseAuthentication();

            app.MapControllers();

            app.Run();
        }
    }
}
