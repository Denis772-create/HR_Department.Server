using Ardalis.Specification.EntityFrameworkCore;
using HR.Department.Core.Interfaces;

namespace HR.Department.Infrastructure.Data
{
    public class Repository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class
    {
        public Repository(DepartmentContext dbContext) : base(dbContext)
        { }
    }
}
