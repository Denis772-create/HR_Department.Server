using System.Reflection;
using HR.Department.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace HR.Department.Infrastructure
{
    public class DepartmentContext : DbContext
    {
        public DepartmentContext(DbContextOptions<DepartmentContext> options) : base(options) { }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<TypePosition> Types { get; set; }
        public DbSet<PositionEmployee> PositionEmployees { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
