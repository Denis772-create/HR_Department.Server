using System;
using MediatR;

namespace HR.Department.WebApi.Features.Employee.Comands.Update
{
    public class UpdateEmployeeCommand : IRequest
    {   
        public Guid Id { get; set; }
        public string Street { get;  set; }
        public string City { get;  set; }
        public string Country { get;  set; }
    }
}
