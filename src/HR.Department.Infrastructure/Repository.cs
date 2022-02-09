using Ardalis.Specification.EntityFrameworkCore;
using HR.Department.Core.Entities;
using HR.Department.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HR.Department.Infrastructure
{
    public class Repository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class
    {
        public Repository(DepartmentContext dbContext) : base(dbContext)=>
            PositionEmployees = dbContext.PositionEmployees;
        public DbSet<PositionEmployee> PositionEmployees { get; set; }
    }
}
