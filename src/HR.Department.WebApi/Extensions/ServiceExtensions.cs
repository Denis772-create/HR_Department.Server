using System;
using System.IO;
using System.Reflection;
using HR.Department.Infrastructure;
using HR.Department.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace HR.Department.WebApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DepartmentContext>(options =>
            {
                options.UseSqlServer(connectionString, b =>
                    b.MigrationsAssembly(typeof(DepartmentContext).Assembly.GetName().Name));
                options.UseLazyLoadingProxies();
            });
        }

        public static void ConfigureSwagger(this IServiceCollection services) =>
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HR.Department.WebApi", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

        public static void ConfigureJwt(this IServiceCollection services,
            IConfiguration configuration) =>
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, config =>
                {
                    config.TokenValidationParameters = new TokenValidationParameters
                    {
                        ClockSkew = TimeSpan.FromSeconds(5),
                        ValidateAudience = false
                    };

                    config.Authority = "https://localhost:6001";
                    config.Audience = "https://localhost:6001";
                });

    }
}
