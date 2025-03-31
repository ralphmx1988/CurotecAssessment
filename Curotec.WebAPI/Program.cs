using Curotec.Application.Extensions;
using Curotec.Application.Models;
using Curotec.Application.Services.User;
using Curotec.Persistence.Context;
using Curotec.Persistence.Extensions;
using Curotec.WebAPI.Extensions;
using Curotec.WebAPI.Middleware;
using Microsoft.OpenApi.Models;

namespace Curotec.WebAPI
{
    public class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <param name="args">An array of command-line arguments.</param>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configure services

            builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.ConfigurePersistence(builder.Configuration);
            builder.Services.ConfigureApplication();
            builder.Services.ConfigureApiBehavior();
            builder.Services.ConfigureCorsPolicy();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(swagger =>
            {
                //This is to generate the Default UI of Swagger Documentation
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Curotec Assessment API",
                    Description = ".NET 8 Web API"
                });
                // To Enable authorization using Swagger (JWT)
                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                });
                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        []

                    }
                });
            });

            var app = builder.Build();

         

            // Ensure database is created
            var serviceScope = app.Services.CreateScope();
            var dataContext = serviceScope.ServiceProvider.GetService<CurotecContext>();
            dataContext?.Database.EnsureCreated();

            // Configure middleware
            app.UseMiddleware<JwtMiddleware>();
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseErrorHandler();
            app.UseCors();
            app.MapControllers();
            app.Run();
        }
    }
}
