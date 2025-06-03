using UserAuthApp.Domain.Interfaces;
using UserAuthApp.Infrastructure.Notifications;
using UserAuthApp.Infrastructure.Repositories;
using UserAuthApp.Application.Services;
using Microsoft.OpenApi.Models;

namespace UserAuthApp.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Register services
            builder.Services.AddScoped<IUserRepository, InMemoryUserRepository>();
            builder.Services.AddScoped<INotificationService, ConsoleNotificationService>();
            builder.Services.AddScoped<AuthService>();

            builder.Services.AddControllers();

            // Enable CORS for all origins, headers, and methods (for testing only)
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "UserAuthApp API", Version = "v1" });
            });

            var app = builder.Build();

            // Use CORS policy
            app.UseCors("AllowAll");

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "UserAuthApp API v1");
                });
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
