using System;
using HR.Department.Core.Entities.ValueObjects;
using HR.Department.WebApi.Modes;
using MediatR;

namespace HR.Department.WebApi.Features.Employee.Comands.Update
{
    public class UpdateEmployeeCommand : IRequest
    {
        public Guid Id { get; set; }
        public AddressDto Address { get; set; }
    }
}
