using System.Reflection;
using HR.Department.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HR.Department.Infrastructure
{
    public static class StartupSetup
    {
        public static void AddDbContext(this IServiceCollection services, string connectionString) =>
            services.AddDbContext<DepartmentContext>(options =>
                options.UseSqlServer(connectionString, b => 
                    b.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name)));
    }
}
