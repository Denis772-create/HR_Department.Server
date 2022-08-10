using HR.Department.Core.Behaviors;
using HR.Department.Core.Interfaces;
using HR.Department.Infrastructure;
using HR.Department.Infrastructure.Data;
using HR.Department.WebApi.Mappings;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace HR.Department.WebApi.Extensions
{
    public static class ConfigureCoreServices
    {
        public static void AddCoreServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddAutoMapper(config =>
                config.AddProfile(new AssemblyMappingProfile(typeof(IMapWith<>).Assembly)));

            services.AddScoped(typeof(IReadRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
