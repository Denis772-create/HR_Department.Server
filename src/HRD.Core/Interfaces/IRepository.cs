using Ardalis.Specification;
using HR.Department.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace HR.Department.Core.Interfaces
{
    public interface IRepository<T> : IRepositoryBase<T> where T : class
    {
         DbSet<PositionEmployee> PositionEmployees { get; set; }
    }
}
