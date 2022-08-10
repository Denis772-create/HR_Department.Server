using Ardalis.Specification;
using HR.Department.Core.Entities;

namespace HR.Department.Core.Specifications
{
    public sealed class EmployeeByPhoneSpecification : Specification<Employee>, ISingleResultSpecification
    {
        public EmployeeByPhoneSpecification(string phone)
        {
            Query.Where(e => e.Phone == phone);
        }
    }
}
