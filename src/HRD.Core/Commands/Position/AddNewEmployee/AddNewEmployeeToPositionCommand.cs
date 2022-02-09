using System;
using MediatR;

namespace HR.Department.Core.Commands.Position.AddNewEmployee
{
    public class AddNewEmployeeToPositionCommand : IRequest
    {
        public Guid PositionId { get; set; }
        public string FirstName { get;  set; }
        public string Surname { get;  set; }
        public string Street { get;  set; }
        public string City { get;  set; }
        public string Country { get;  set; }
        public string Phone { get;  set; }
        public int Age { get;  set; }
        public decimal RequiredSalary { get; set; }
    }
}
