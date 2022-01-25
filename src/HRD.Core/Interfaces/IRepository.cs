using Ardalis.Specification;

namespace HR.Department.Core.Interfaces
{
    public interface IRepository<T> : IRepositoryBase<T> where T : class
    { }
}
