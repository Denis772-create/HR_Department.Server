using System;
using System.Collections.Generic;
using System.Linq;

namespace HR.Department.Core.Entities
{
    public class Position : BaseEntity
    {
        public string Name { get; private set; }
        public Guid TypePositionId { get; private set; }
        public TypePosition TypePosition { get; private set; }

        private readonly List<Employee> _employees = new();
        public IReadOnlyCollection<Employee> Employees => _employees.AsReadOnly();

        public Position(string name, Guid typePositionId, TypePosition typePosition)
        {
            Name = name;
            TypePositionId = typePositionId;
            TypePosition = typePosition;
        }
        public Position() { }

        public void AddEmployee(Employee employee)
        {
            if (!Employees.Any(em => em.Id == employee.Id))
                _employees.Add(employee);
        }
    }
}
