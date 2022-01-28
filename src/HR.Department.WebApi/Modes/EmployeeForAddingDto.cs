using System;

namespace HR.Department.WebApi.Modes
{
    public class EmployeeForAddingDto
    {
        public Guid PositionId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        public decimal RequiredSalary { get; set; }
    }
}
