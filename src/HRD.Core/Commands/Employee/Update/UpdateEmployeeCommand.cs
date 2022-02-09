using System;
using HR.Department.Core.Dto;
using MediatR;

namespace HR.Department.Core.Commands.Employee.Update
{
    public class UpdateEmployeeCommand : IRequest
    {
        public Guid Id { get; set; }
        public AddressDto Address { get; set; }
    }
}
