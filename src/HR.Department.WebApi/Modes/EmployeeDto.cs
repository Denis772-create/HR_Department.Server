using HR.Department.Core.Entities.ValueObjects;

namespace HR.Department.WebApi.Modes
{
    public class EmployeeDto
    {
        public string FirstName { get; private set; }
        public string Surname { get; private set; }
        public string Phone { get; private set; }
    }
}
