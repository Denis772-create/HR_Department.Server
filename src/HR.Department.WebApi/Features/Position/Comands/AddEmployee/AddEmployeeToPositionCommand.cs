using System;
using MediatR;

namespace HR.Department.WebApi.Features.Position.Comands.AddEmployee
{
    public class AddEmployeeToPositionCommand : IRequest
    {
        public Guid PositionId { get; set; }
        public string FirstName { get;  set; }
        public string Surname { get;  set; }
        public string Street { get;  set; }
        public string City { get;  set; }
        public string Country { get;  set; }
        public string Phone { get;  set; }
        public int Age { get;  set; }
    }
}
