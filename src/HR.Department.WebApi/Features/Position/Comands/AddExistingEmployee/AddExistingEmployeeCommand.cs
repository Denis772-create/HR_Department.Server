using System;
using MediatR;

namespace HR.Department.WebApi.Features.Position.Comands.AddExistingEmployee
{
    public class AddExistingEmployeeCommand : IRequest
    {
        public Guid PositionId { get; set; }
        public Guid EmployeeId { get; set; }
    }
}
