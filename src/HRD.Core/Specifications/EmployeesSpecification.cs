using System;
using System.Linq;
using Ardalis.Specification;
using HR.Department.Core.Entities;

namespace HR.Department.Core.Specifications
{
    public sealed class EmployeesSpecification : Specification<Employee>
    {
        public EmployeesSpecification(Guid id)
        {
            Query.Where(e => e.Positions.Select(p => p.Id).Contains(id));
        }
    }
}
