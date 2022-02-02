using System;
using System.Collections.Generic;
using System.Linq;

namespace HR.Department.Core.Entities
{
    public class Position : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Guid TypePositionId { get; private set; }
        public virtual TypePosition TypePosition { get; private set; }

        private readonly List<Employee> _employees = new();
        public virtual IReadOnlyCollection<Employee> Employees => _employees.AsReadOnly();

        public Position(string name, Guid typePositionId, string description)
        {
            Name = name;
            TypePositionId = typePositionId;
            Description = description;
        }
        public Position(string description)
        {
            Description = description;
        }

        public void AddEmployee(Employee employee)
        {
            if (!Employees.Any(em => em.Id == employee.Id))
                _employees.Add(employee);
        }

        public void RemoveEmployee(Guid employeeId)
        {
            var employee = Employees.FirstOrDefault(e => e.Id == employeeId);

            if (employee != null)
                _employees.Remove(employee);
        }

        public void Update(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
