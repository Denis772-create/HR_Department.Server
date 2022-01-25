using Ardalis.Specification;

namespace HR.Department.Core.Interfaces
{
    public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class
    { }
}
